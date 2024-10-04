import { Student } from "@interfaces/interfaces";

interface StudentRowProps {
    student: Student;
}

const StudentRow: React.FC<StudentRowProps> = ({ student }) => {
    return(
        <tr>
            <td className="border px-4 py-2">{student.id}</td>
            <td className="border px-4 py-2">{student.surname}</td>
            <td className="border px-4 py-2">{student.name}</td>
            <td className="border px-4 py-2">{student.patronymic}</td>
        </tr>
    )
}

export default StudentRow;