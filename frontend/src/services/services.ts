import { Classroom, Employee, Classroom, Student } from "@interfaces/interfaces";

const classrooms: Classroom[] = [
    { id: 1, number: '1', name: 'A', subjectsCount: 10 },
    { id: 2, number: '2', name: 'Б', subjectsCount: 10 },
    { id: 3, number: '3', name: 'В', subjectsCount: 10 },
    { id: 4, number: '4', name: 'Г', subjectsCount: 10 },
    { id: 5, number: '5', name: 'Д', subjectsCount: 10 },
    { id: 6, number: '6', name: 'Е', subjectsCount: 10 },
    { id: 7, number: '7', name: 'Ё', subjectsCount: 10 },
    { id: 8, number: '8', name: 'Ж', subjectsCount: 10 },
    { id: 9, number: '9', name: 'З', subjectsCount: 10 },
    { id: 10, number: '10', name: 'И', subjectsCount: 10 },
    { id: 11, number: '11', name: 'К', subjectsCount: 10 },
]

const employees: Employee[] = [
    { id: 1, fullName: 'Иван Иванов' },
    { id: 2, fullName: 'Мария Петрова' },
    { id: 3, fullName: 'Сергей Сидоров' },
    { id: 4, fullName: 'Анна Кузнецова' },
    { id: 5, fullName: 'Дмитрий Смирнов' },
    { id: 6, fullName: 'Екатерина Федорова' },
    { id: 7, fullName: 'Алексей Попов' },
    { id: 8, fullName: 'Ольга Васильева' },
    { id: 9, fullName: 'Николай Николаев' },
    { id: 10, fullName: 'Татьяна Романова' },
]

const students: Student[] = [
    {id: '123', surname: 'Иванов', name: 'Иван', patronymic: 'Иванович'},
    {id: '123', surname: 'Петров', name: 'Петр', patronymic: 'Петрович'},
    {id: '123', surname: 'Сидоров', name: 'Радион', patronymic: 'Радионович'},
    {id: '123', surname: 'Тришин', name: 'Петр', patronymic: 'Петрович'}
]

function delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
}

export const fetchClassroomsAsync = async () : Promise<Classroom[]> => {
    await delay(1000);
    return Promise.resolve(classrooms)
}

export const fetchEmployeesAsync = async () : Promise<Employee[]> => {
    await delay(1000);
    return Promise.resolve(employees)
}

export const fetchStudentsByClassId = async (id: number) : Promise<Student[]> => {
    await delay(1000);
    return Promise.resolve(students)
}

export const fetchStudentById = async(id: number): Promise<Student> => {
    await delay(1000);
    return Promise.resolve(students[0]);
}