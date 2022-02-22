#pragma once
#include <string>
#include <cstdint>
#include "Faculty.h"
#define STUDENT_DATA "Student.fl"
#define STUDENT_GARBAGE "Student_garbage.txt"

struct Student {
	int studentId;
	int facultyId;
	int grade;
	bool ifExist;
	int32_t address;
	int32_t nextAddress;
};

bool getStudent(Faculty& faculty, Student& student, int student_id);
void updateStudent(Student& student);
bool insertStudent(Faculty& faculty, Student& student);
void deleteStudent(Faculty& faculty, Student& student);


