import { Classroom, Student } from "@interfaces/interfaces";
import { Card, CardContent, CircularProgress, Skeleton, Typography } from "@mui/material";

interface StudentInfoProps {
    student: Student;
    classroom: Classroom
}

const StudentInfo: React.FC<StudentInfoProps> = ({student, classroom}) => {
    return (
        <>
            <Card className="max-w-sm mx-auto shadow-lg rounded-lg">
            <CardContent className="p-6">
                <Typography variant="h5" component="div" className="font-bold mb-2 text-center">
                    Информация о ученике
                </Typography>

                {!student ? (
                    <>
                        <Skeleton variant="text" width="60%" />
                        <Skeleton variant="text" width="60%" />
                        <Skeleton variant="text" width="60%" />
                        <Skeleton variant="text" width="60%" />
                    </>
                ) : (
                    <>
                        <Typography variant="body1" component="p" className="mb-1">
                            <strong>Фамилия:</strong> {student?.surname || '—'}
                        </Typography>
                        <Typography variant="body1" component="p" className="mb-1">
                            <strong>Имя:</strong> {student?.name || '—'}
                        </Typography>
                        <Typography variant="body1" component="p" className="mb-1">
                            <strong>Отчество:</strong> {student?.patronymic || '—'}
                        </Typography>
                        <Typography variant="body1" component="p" className="mb-1">
                            <strong>Класс: </strong>
                            {classroom ? (
                                <span>{`${classroom.number} ${classroom.name}`}</span>
                            ) : (
                                <Skeleton animation="wave" width="100px" style={{ display: 'inline-block', verticalAlign: 'middle' }} />
                            )}
                        </Typography>
                    </>
                )}
            </CardContent>
        </Card>
        </>
    )
};

export default StudentInfo;