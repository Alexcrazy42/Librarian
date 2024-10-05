import { Employee } from "@interfaces/interfaces";
import { Card, CardContent, CircularProgress, Typography } from "@mui/material";
import { fetchEmployeeById } from "@services/services";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import EmployeeInfo from "./components/employeeInfo";
import EducationalBookRents from "./components/educationalBookRents";
import FictionBookRents from "./components/fictionBookRents";

const EmployeePage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [employee, setEmployee] = useState<Employee | null>(null);

    useEffect(() => {
        fetchEmployeeById(Number(id))
            .then(data => {
                setEmployee(data);
            });
    }, []);

    return (
        <>
            <EmployeeInfo employee={employee} />

            <EducationalBookRents />

            <FictionBookRents />
        </>
    );
}

export default EmployeePage;