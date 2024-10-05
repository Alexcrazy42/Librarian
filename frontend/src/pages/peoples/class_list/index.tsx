import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { Student } from "@interfaces/interfaces";
import StudentTable from "./components/studentTable";
import { fetchStudentsByClassId } from "@services/services";
import { CircularProgress } from "@mui/material";

const ClassList: React.FC = () => {
    const { id } = useParams();
    const [students, setStudents] = useState<Student[]>([]);

    useEffect(() => {
        fetchStudentsByClassId(Number(id))
            .then(data => {
                setStudents(data);
            });
    }, [id]);

    
    return(
        <>
            <div className="p-4">
                <StudentTable students={students} />
            </div>
        </>
    )
}

export default ClassList;