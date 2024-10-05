import { Employee } from "@interfaces/interfaces";
import { Card, CardContent, Typography, Skeleton } from "@mui/material";

interface EmployeeInfoProps {
    employee: Employee
}

const EmployeeInfo: React.FC<EmployeeInfoProps> = ({employee}) => {
    return(
        <>
            <Card className="max-w-sm mx-auto shadow-lg rounded-lg">
                <CardContent className="p-6">
                    <Typography variant="h5" component="div" className="font-bold mb-2 text-center">
                        Информация о работнике
                    </Typography>
                    <Typography variant="body1" component="p" className="mb-1">
                        {employee? (
                            employee.fullName
                        ) : (
                            <Skeleton animation="wave" width="200px" />
                        )}
                    </Typography>
                </CardContent>
            </Card>
        </>
    )
}

export default EmployeeInfo;