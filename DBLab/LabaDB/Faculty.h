#pragma once
#include <string>
#include <cstdint>
#define FACULTY_DATA "Faculty.fl"
#define FACULTY_INDEX "Faculty.ind"
#define FACULTY_GARBAGE "FacultyGarbage.txt"

struct Faculty
{
	int id;
	int studentsCount = 0;
	std::string name;
	int32_t firstStudentAddress = -1;
	
};
struct Index {
	int id;
	int32_t address;
	bool ifExist;
};
bool getFaculty(Faculty& faculty, int id);
bool deleteFaculty(Faculty& faculty);
bool updateFaculty(Faculty& faculty);
void insertFaculty(Faculty& faculty);
