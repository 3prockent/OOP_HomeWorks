#include <iostream>

#include "Faculty.h"
#include "Student.h"
#include <map>



void menu(int& request);
bool checkUnique(Faculty& faculty, int studentId);
void allInfo(Faculty& faculty);
int sbSize();


int main()
{
    Faculty faculty;
    Student student;
    
    while (true) {
        std::string temp = "";
        int request = 0;
        int id = 0, student_id = 0, grade = 0;
        menu(request);
        switch (request) {
        case 0:
            allInfo(faculty);

            break;
        case 1:
            
            std::cout << "Enter the faculty's id: ";
            std::cin >> id;
            if (getFaculty(faculty, id)) {
                std::cout << "Faculty's name is " << faculty.name << std::endl;
            }
            else {
                std::cout << "There is no faculty with id " << id << std::endl;
            }
            break;
        case 2:
            
            std::cout << "Enter the faculty's id: ";
            std::cin >> id;

            if (getFaculty(faculty, id)) {
                int student_id = 0;
                std::cout << "Enter the student's id: ";
                std::cin >> student_id;

                if (getStudent(faculty, student, student_id)) {
                    std::cout << "Student's grade is " << student.grade << std::endl;
                }
                else {
                    std::cout << "No student" << std::endl;
                }
            }
            else {
                std::cout << "No faculty" << std::endl;
            }

            break;
        case 3:
            std::cout << "Enter the faculty's name: ";
            std::cin >> temp;
            faculty.name = temp;

            insertFaculty(faculty);
            std::cout << "A new faculty added into the DB" << std::endl;
            std::cout << "A new faculty's ID is " << faculty.id << std::endl;

            break;
        case 4:
            
            std::cout << "Enter the faculty's id: ";
            std::cin >> id;
            if (getFaculty(faculty, id)) {
                std::cout << "Enter the student's grade: ";
                std::cin >> grade;
                std::cout << "Enter the student's id: ";
                std::cin >> student_id;
                student.facultyId = id;
                student.grade = grade;
                if (checkUnique(faculty, student_id)) {
                    student.studentId = student_id;
                    insertStudent(faculty, student);
                    std::cout << "A new student added into the DB with the faculty ID " << faculty.id << std::endl;
                    std::cout << "A new student's ID is " << student.studentId << std::endl;
                }
            }

            break;
        case 5:
            std::cout << "Enter the faculty's id: ";
            std::cin >> id;
            if (getFaculty(faculty, id)) {
                std::cout << "Enter a new faculty's name: ";
                std::cin >> temp;
                faculty.name = temp;
                if (updateFaculty(faculty)) {
                    std::cout << "Correct" << std::endl;
                    std::cout << "Faculty's name is " << faculty.name << std::endl;
                    std::cout << "Faculty's id is " << faculty.id << std::endl;
                    break;
                }
                std::cout << "Error" << std::endl;
            }
            else {
                std::cout << "No faculty" << std::endl;
            }

            break;
        case 6:
            std::cout << "Enter the faculty's id: ";
            std::cin >> id;
            if (getFaculty(faculty, id)) {
                std::cout << "Enter student's id: ";
                std::cin >> student_id;
                
                if (getStudent(faculty, student, student_id)) {
                    std::cout << "Enter new student's grade: ";
                    std::cin >> grade;
                    student.grade = grade;
                    updateStudent(student);
                    std::cout << "A new student's grade is " << student.grade << std::endl;
                    
                    break;
                }
                std::cout << "No Student" << std::endl;
            }
            else {
                std::cout << "No faculty" << std::endl;
            }

            break;
        case 7:
            
            std::cout << "Enter the faculty's id: ";
            std::cin >> id;
            if (getFaculty(faculty, id)) {
                if (deleteFaculty(faculty)) {
                    std::cout << "The faculty with ID " << faculty.id << " has been removed" << std::endl;
                    break;
                }
                std::cout << "Error" << std::endl;
            }
            else {
                std::cout << "No faculty" << std::endl;
            }

            break;
        case 8:
            
            std::cout << "Enter the faculty's id: ";
            std::cin >> id;
            if (getFaculty(faculty, id)) {
                int student_id = 0;
                std::cout << "Enter the student's id: ";
                std::cin >> student_id;
                if (getStudent(faculty, student, student_id)) {
                    deleteStudent(faculty, student);
                    std::cout << "The student with id" << student.studentId << " has been removed" << std::endl;
                    break;
                }
                std::cout << "No student" << std::endl;
            }
            else {
                std::cout << "No faculty" << std::endl;
            }

            break;
        case 9:
            exit(1);
            return 0;
        }
    }
}
bool checkUnique(Faculty& faculty,int studentId)
{
    FILE* student_db = fopen(STUDENT_DATA, "r+b");
    if (student_db == nullptr) {
        return true;
    }
    Student student;

    fseek(student_db, faculty.firstStudentAddress, SEEK_SET);

    for (int i = 0; i < faculty.studentsCount; i++)
    {
        fread(&student, sizeof(Student), 1, student_db);
        fclose(student_db);

        if (student.studentId == studentId)
        {
            return false;
        }

        student_db = fopen(STUDENT_DATA, "r+b");
        fseek(student_db, student.nextAddress, SEEK_SET);
    }

    fclose(student_db);

    return true;
}
void menu(int& request) {
    std::cout << "Choose Options:\n"<<
        "***********************************\n" <<
        "0 : Get DBInfo,\n"<<
        "1 : Get info about Faculty,\n"<<
        "2 ; Get indo about Student,\n"<<
        "3 : Add new faculty,\n"<<
        "4 : Add new student,\n"<<
        "5 : Update exist faculty,\n"<<
        "6 : Update exist student,\n"<<
        "7 : Remove faculty,\n"<<
        "8 : Remove student,\n"<<
        "***********************************\n"
        "> ";
    std::cin >> request;
}
int sbSize() {
    FILE* faculty_index = fopen(FACULTY_INDEX, "rb");
    if (faculty_index == nullptr) {
        return 0;
    }
    fseek(faculty_index, 0, SEEK_END);
    int64_t tableSize = ftell(faculty_index);
    if (!tableSize) {
        return 0;
    }
    fclose(faculty_index);
    return tableSize / sizeof(Index);
}
void allInfo(Faculty& faculty) {
    bool flag = false;

    std::map<int, int> info;

    int indAmount = sbSize();
   
    for (int i = 1; i <= indAmount; ++i) {
        if (getFaculty(faculty, i)) {
            info[i] = faculty.studentsCount;
        }
    }
    for (const auto& [key, value] : info) {
        flag = true;
        std::cout << "Faculty with ID " << key << " has " << value << " students." << std::endl;
    }
    if (!flag) {
        std::cout << "No info in the DB" << std::endl;
    }
}