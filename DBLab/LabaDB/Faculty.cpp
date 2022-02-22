#include "Faculty.h"
#include "Student.h"
#include <vector>
#include <cstdint>
#include <iostream>


void rebornFaculty(FILE* garbage, Faculty& faculty, int& garbageCount) {
	std::vector<int> deletedStudents(garbageCount);
	for (int i = 0; i < garbageCount; ++i) {
		fread(&deletedStudents[i], sizeof(int), 1, garbage);
	}
	faculty.id = deletedStudents[0];
	

	fclose(garbage);
	garbage = fopen(FACULTY_GARBAGE, "wb");
	--garbageCount;
	fwrite(&garbageCount, sizeof(int), 1, garbage);
	for (int i = 1; i <= garbageCount; ++i) {
		fwrite(&deletedStudents[i], sizeof(int), 1, garbage);
	}
	fclose(garbage);
}

void addFacultyToGarbage(Faculty& faculty) {
	int garbageCount = 0;
	FILE* garbage = fopen(FACULTY_GARBAGE, "rb");
	fread(&garbageCount, sizeof(int), 1, garbage);


	std::vector<int> deletedFacultys(garbageCount);
	for (int i = 0; i < garbageCount; ++i) {
		fread(&deletedFacultys[i], sizeof(int), 1, garbage);
	}
	fclose(garbage);
	garbage = fopen(FACULTY_GARBAGE, "wb");
	++garbageCount;
	fwrite(&garbageCount, sizeof(int), 1, garbage);
	for (int i = 0; i < garbageCount - 1; ++i) {
		fwrite(&deletedFacultys[i], sizeof(int), 1, garbage);
	}
	fwrite(&faculty.id, sizeof(int), 1, garbage);
	fclose(garbage);
}
bool getFaculty(Faculty& faculty, int id) {
	FILE* faculty_db = fopen(FACULTY_DATA, "rb");
	FILE* faculty_index = fopen(FACULTY_INDEX, "rb");
	if (faculty_db == NULL || faculty_index == NULL) {
		return false;
	}
	fseek(faculty_index, 0, SEEK_END);
	int64_t tableSize= ftell(faculty_index);
	if (!tableSize || id * sizeof(Index) > tableSize) {
		fclose(faculty_db);
		fclose(faculty_index);
		return false;
	}
	Index index;
	fseek(faculty_index, (id - 1) * sizeof(Index), SEEK_SET);
	fread(&index, sizeof(Index), 1, faculty_index);

	if (!index.ifExist) {
		fclose(faculty_db);
		fclose(faculty_index);
		return false;
	}

	fseek(faculty_db, index.address, SEEK_SET);
	fread(&faculty, sizeof(Faculty), 1, faculty_db);
	fclose(faculty_db);
	fclose(faculty_index);
	return true;
}

bool deleteFaculty(Faculty& faculty) {
	FILE* faculty_db = fopen(FACULTY_DATA, "r+b");
	FILE* faculty_index = fopen(FACULTY_INDEX, "r+b");

	if (faculty_index == nullptr) {
		return false;
	}
	fseek(faculty_index, 0, SEEK_END);
	int64_t tableSize = ftell(faculty_index);
	if (!tableSize || faculty.id * sizeof(Index) > tableSize) {
		fclose(faculty_db);
		fclose(faculty_index);
		return false;
	}
	Index index;
	fseek(faculty_index, (faculty.id - 1) * sizeof(Index), SEEK_SET);
	fread(&index, sizeof(Index), 1, faculty_index);

	index.ifExist = false;
	fseek(faculty_index, (faculty.id - 1) * sizeof(Index), SEEK_SET);
	fwrite(&index, sizeof(Index), 1, faculty_index);
	fclose(faculty_index);
	addFacultyToGarbage(faculty);

	if (faculty.studentsCount) {
		FILE* students_db = fopen(STUDENT_DATA, "r+b");
		fseek(students_db, faculty.firstStudentAddress, SEEK_SET);

		Student student;
		int studentsCount = faculty.studentsCount;
		for (int i = 0; i < studentsCount; ++i) {
			fread(&student, sizeof(Student), 1, students_db);
			fclose(students_db);
			deleteStudent(faculty, student);

			students_db = fopen(STUDENT_DATA, "r+b");
			fseek(students_db, student.nextAddress, SEEK_SET);
		}
		fclose(students_db);
	}
	return true;
}
bool updateFaculty(Faculty& faculty) {
	FILE* faculty_index = fopen(FACULTY_INDEX, "r+b");
	FILE* faculty_db = fopen(FACULTY_DATA, "r+b");

	if (faculty_index == nullptr || faculty_db == nullptr) {
		return false;
	}

	Index index;
	int id = faculty.id;
	fseek(faculty_index, 0, SEEK_END);
	int64_t tableSize = ftell(faculty_index);
	if (!tableSize || id * sizeof(Index) > tableSize) {
		fclose(faculty_index);
		fclose(faculty_db);
		return false;
	}
	

	fseek(faculty_index, (id - 1) * sizeof(Index), SEEK_SET);
	fread(&index, sizeof(Index), 1, faculty_index);

	if (!index.ifExist) {
		fclose(faculty_index);
		fclose(faculty_db);
		return false;
	}

	fseek(faculty_db, index.address, SEEK_SET);
	fwrite(&faculty, sizeof(Faculty), 1, faculty_db);
	fclose(faculty_index);
	fclose(faculty_db);

	return true;
}
void insertFaculty(Faculty& faculty) {
	faculty.firstStudentAddress = -1;
	faculty.studentsCount = 0;
	FILE * faculty_index = fopen(FACULTY_INDEX, "a+b");
	FILE* faculty_db = fopen(FACULTY_DATA, "a+b");
	FILE* garbage = fopen(FACULTY_GARBAGE, "a+b");

	int garbageCount = 0;
	fread(&garbageCount, sizeof(int), 1, garbage);
	Index index;
	if (garbageCount) {
		rebornFaculty(garbage, faculty, garbageCount);
		fclose(faculty_index);
		fclose(faculty_db);
		faculty_index = fopen(FACULTY_INDEX, "r+b");
		faculty_db = fopen(FACULTY_DATA, "r+b");
		fseek(faculty_index, (faculty.id - 1) * sizeof(Index), SEEK_SET);
		fread(&index, sizeof(Index), 1, faculty_index);
		fseek(faculty_db, index.address, SEEK_SET);
	}
	else {
		fseek(faculty_index, 0, SEEK_END);

		if (ftell(faculty_index))
		{
			int temp_size = sizeof(Index);
			fseek(faculty_index, -temp_size, SEEK_END);
			fread(&index, sizeof(Index), 1, faculty_index);

			faculty.id = index.id + 1;
		}
		else
		{
			faculty.id = 1;
		}
	}
	fwrite(&faculty, sizeof(Faculty), 1, faculty_db);

	index.id = faculty.id;
	index.address = (faculty.id - 1) * sizeof(Faculty);
	index.ifExist = true;

	fseek(faculty_index, (faculty.id - 1) * sizeof(Index), SEEK_SET);
	fwrite(&index, sizeof(Index), 1, faculty_index);
	fclose(faculty_index);
	fclose(faculty_db);
}
