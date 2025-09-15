# School Management System

A comprehensive School Management System implemented in C# using the **Strategy Pattern** design approach. This application provides robust functionality for managing students, courses, enrollments, and grade assignments within an educational institution.

## Features

- **Student Management:** Complete student information handling with enrollment tracking
- **Course Management:** Course creation and management with enrollment capacity
- **Dynamic Enrollment:** Enroll and drop students from courses with validation
- **Grade Management:** Assign and view grades for enrolled students
- **Interactive Console Interface:** User-friendly menu-driven console application
- **Strategy Pattern Implementation:** Modular design using interfaces for extensible functionality
- **Seed Data:** Pre-populated test data for immediate system testing

## Architecture & Design Patterns

This project implements the **Strategy Pattern** to create a flexible and maintainable codebase:

- **IStudentServices Interface:** Defines contracts for student-related operations
- **Concrete Strategy Classes:** Separate implementations for enrollment, grade assignment, and viewing operations
- **Modular Design:** Clean separation of concerns with dedicated service classes

## Project Structure

### Core Classes

- `Student.cs`: Student entity with enrollment tracking capabilities
- `Course.cs`: Course entity with student enrollment management
- `Enrollment.cs`: Junction entity handling student-course relationships with grades
- `Program.cs`: Application entry point with main menu logic
- `ConsoleLogs.cs`: User interface management and console output formatting
- `seeds.cs`: Test data initialization for students and courses

### Strategy Pattern Implementation

- `Interface_&_Classes/IStudentServices.cs`: Service contract interface
- `Interface_&_Classes/EnrollInCourse.cs`: Course enrollment strategy
- `Interface_&_Classes/DropCourse.cs`: Course withdrawal strategy
- `Interface_&_Classes/AssignGrades.cs`: Grade assignment strategy
- `Interface_&_Classes/ViewGrades.cs`: Grade viewing strategy

### Legacy Code

- `Methods.cs`: Legacy static helper methods (currently commented out)

### Project Configuration

- `School_Management_System.csproj`: .NET 9.0 project configuration
- `School_Management_System.sln`: Visual Studio solution file

## Sample Data

The system comes with pre-populated test data:

**Students:**

- Hesham (ID: 111)
- Eslam (ID: 222)
- Farag (ID: 333)
- Fat7y (ID: 444)
- Adel (ID: 555)

**Courses:**

- MAT101 - Calculus I (4 credits)
- PHY101 - Physics I (2 credits)
- STA101 - Statistics & Probability (2 credits)
- CSE101 - Introduction to Programming (3 credits)
- DSA101 - Data Structures (3 credits)

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or later (recommended)
- Git for version control

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Hesham766/InternCode.git
   ```
2. Navigate to the project directory
3. Open `School_Management_System.sln` in Visual Studio
4. Build the solution (Ctrl+Shift+B)
5. Run the project (F5 or Ctrl+F5)

## Usage

The application provides a menu-driven interface with the following options:

1. **Enroll Course** - Add a student to a course
2. **Drop Course** - Remove a student from a course
3. **View Enrolled Courses** - Display all enrolled courses
4. **Assign Grade** - Set grades for student enrollments
5. **View Grades** - Display grades for specific students
6. **Exit** - Close the application

### Sample Workflow

1. Start the application
2. Choose option 1 to enroll a student
3. Enter a course code (e.g., "CSE101")
4. Enter a student ID (e.g., "111")
5. Use option 4 to assign grades
6. Use option 5 to view assigned grades

## Development Branch

Current development is happening on the `Strategy_Pattern` branch, which includes:

- Implementation of the Strategy design pattern
- Interface-based architecture for service operations
- Enhanced modularity and extensibility

## Future Enhancements

- Complete Strategy Pattern implementation for all operations
- Database integration for persistent data storage
- Web-based user interface
- Advanced reporting and analytics
- Course prerequisite management
- Student transcript generation

## Contributing

This is an educational project. Contributions and suggestions are welcome for learning purposes.

## License

This project is developed for educational purposes and does not include a specific license.
