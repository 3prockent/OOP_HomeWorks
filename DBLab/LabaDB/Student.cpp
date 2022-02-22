#include <iostream>
#include <fstream>
#include <vector>
#include "Student.h"
#include "Faculty.h"


void rebornStudent(FILE * garbage, int& garbageCount, Student& student) {
	std::vector<int32_t> deletedStudents(garbageCount);
	for (int i = 0; i < garbageCount; ++i) {
		fread(&deletedStudents[i], sizeof(int32_t), 1, garbage);
	}
	student.address = deletedStudents[0];
	student.nextAddress = deletedStudents[0];

	fclose(garbage);
	garbage = fopen(STUDENT_GARBAGE, "wb");
	--garbageCount;
	fwrite(&garbageCount, sizeof(int), 1, garbage);
	for (int i = 1; i <= garbageCount; ++i) {
		fwrite(&deletedStudents[i], sizeof(int32_t), 1, garbage);
	}
	fclose(garbage);
}

void addStudentToGarbage(Student& student) {
	int garbageCount = 0;
	FILE* garbage = fopen(STUDENT_GARBAGE, "rb");
	fread(&garbageCount, sizeof(int), 1, garbage);


	std::vector<int32_t> deletedStudents(garbageCount);
	for (int i = 0; i < garbageCount; ++i) {
		fread(&deletedStudents[i], sizeof(int32_t), 1, garbage);
	}
	fclose(garbage);
	garbage = fopen(STUDENT_GARBAGE, "wb");
	++garbageCount;
	fwrite(&garbageCount, sizeof(int), 1, garbage);
	for (int i = 0; i < garbageCount - 1; ++i) {
		fwrite(&deletedStudents[i], sizeof(int32_t), 1, garbage);
	}
	fwrite(&student.address, sizeof(int32_t), 1, garbage);
	fclose(garbage);
}

bool insertStudent(Faculty &faculty, Student& student) {
	student.ifExist = true;
	FILE* db = fopen(STUDENT_DATA, "a+b");
	FILE* garbage = fopen(STUDENT_GARBAGE, "a+b");
	fseek(garbage, 0, SEEK_SET);
	int garbageCount = 0;
	fread(&garbageCount, sizeof(int), 1, garbage);


	if (garbageCount) {
		rebornStudent(garbage, garbageCount, student);
		fclose(db);
		db = fopen(STUDENT_DATA, "r+b");
		fseek(db, student.address, SEEK_SET);
	}
	else {
		
		fseek(db, 0, SEEK_END);
		int db_size = ftell(db);

		student.address = db_size;
		student.nextAddress = db_size;
	}
	fwrite(&student, sizeof(Student), 1, db);
	if (!faculty.studentsCount) {
		faculty.firstStudentAddress = student.address;
	}
	else {
		fclose(db);
		db = fopen(STUDENT_DATA, "r+b");
		Student previous;

		fseek(db, faculty.firstStudentAddress, SEEK_SET);

		for (int i = 0; i < faculty.studentsCount; i++)
		{
			fread(&previous, sizeof(Student), 1, db);
			fseek(db, previous.nextAddress, SEEK_SET);
		}

		previous.nextAddress = student.address;				
		fwrite(&previous, sizeof(Student), 1, db);
	}
	fclose(db);
	faculty.studentsCount += 1;
	updateFaculty(faculty);

	return true;
}

void updateStudent(Student& student) {
	FILE* db = fopen(STUDENT_DATA, "r+b");

	fseek(db, student.address, SEEK_SET);
	fwrite(&student, sizeof(Student), 1, db);

	fclose(db);
}

bool getStudent(Faculty& faculty, Student& student ,int student_id) {
	if (!faculty.studentsCount) {
		return false;
	}
	FILE* db = fopen(STUDENT_DATA, "rb");
	fseek(db, faculty.firstStudentAddress, SEEK_SET);
	fread(&student, sizeof(Student), 1, db);

	for (int i = 0; i < faculty.studentsCount; ++i) {
		if (student.studentId == student_id) {
			fclose(db);
			return true;
		}
		fseek(db, student.nextAddress, SEEK_SET);
		fread(&student, sizeof(Student), 1, db);
	}
	fclose(db);
	return false;
}
void makeLinks(Faculty& faculty, Student& prev, Student& student_to_delete, FILE * db) {
	if (student_to_delete.address == faculty.firstStudentAddress){

		if (student_to_delete.address == student_to_delete.nextAddress){
			faculty.firstStudentAddress = -1;					
		}
		else{
			faculty.firstStudentAddress = student_to_delete.nextAddress;
		}
	}
	else{
		if (student_to_delete.address == student_to_delete.nextAddress){
			prev.nextAddress = prev.address;
		}
		else{
			prev.nextAddress = student_to_delete.nextAddress;
		}

		fseek(db, prev.address, SEEK_SET);
		fwrite(&prev, sizeof(Student), 1, db);
	}
}
void deleteStudent(Faculty& faculty, Student& student) {
	FILE* db = fopen(STUDENT_DATA, "r+b");
	Student prev;
	fseek(db, faculty.firstStudentAddress, SEEK_SET);
	fread(&prev, sizeof(Student), 1, db);

	for (int i = 0; i < faculty.studentsCount; ++i) {
		if (prev.address == student.address || prev.nextAddress == student.address) {
			break;
		}
	}
	makeLinks(faculty, prev, student, db);
	
	student.ifExist = 0;
	addStudentToGarbage(student);


	fseek(db, student.address, SEEK_SET);
	fwrite(&student, sizeof(Student), 1, db);
	fclose(db);

	faculty.studentsCount -= 1;
	updateFaculty(faculty);
	
}