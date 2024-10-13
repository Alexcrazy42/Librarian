import { Classroom, Student } from "@interfaces/interfaces";
import { Button, Card, CardContent, CircularProgress, Skeleton, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import MoveToAnotherClassDialog from "./moveToAnotherClassDialog";

interface StudentInfoProps {
    student: Student;
    classroom: Classroom
}

const StudentInfo: React.FC<StudentInfoProps> = ({student, classroom}) => {

    const [initValue, setInitValues] = useState({
        surname: student?.surname,
        name: student?.name,
        patronymic: student?.patronymic,
    });

    const [values, setValues] = useState(initValue);
    const [moveDialogOpen, setMoveDialogOpen] = useState<boolean>(false);

    const isDirty = values.surname !== initValue.surname ||
        values.name !== initValue.name ||
        values.patronymic !== initValue.patronymic;


    useEffect(() => {
        setInitValues({
            surname: student?.surname,
            name: student?.name,
            patronymic: student?.patronymic,
        })

        setValues({
            surname: student?.surname,
            name: student?.name,
            patronymic: student?.patronymic,
        })
    }, [])

    const handleChange = (event) => {
        const { name, value } = event.target;
        setValues((prev) => ({ ...prev, [name]: value }));
    };

    const handleSave = () => {
        
    };

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
                            <strong>Фамилия:</strong>
                            <TextField
                                name="surname"
                                value={values.surname}
                                onChange={handleChange}
                                variant="outlined"
                                size="small"
                                className="ml-1"
                            />
                        </Typography>
                        <Typography variant="body1" component="p" className="mb-1">
                            <strong>Имя:</strong>
                            <TextField
                                name="name"
                                value={values.name}
                                onChange={handleChange}
                                variant="outlined"
                                size="small"
                                className="ml-1"
                            />
                        </Typography>
                        <Typography variant="body1" component="p" className="mb-1">
                            <strong>Отчество:</strong>
                            <TextField
                                name="patronymic"
                                value={values.patronymic}
                                onChange={handleChange}
                                variant="outlined"
                                size="small"
                                className="ml-1"
                            />
                        </Typography>
                        <Typography variant="body1" component="p" className="mb-1">
                            <strong>Класс:</strong>
                            {classroom ? (
                                <>
                                    <span>{`${classroom.number} ${classroom.name}`}</span>
                                    <Button onClick={() => setMoveDialogOpen(true)}>Перенести в другой класс</Button>
                                </>
                            ) : (
                                <Skeleton animation="wave" width="100px" style={{ display: 'inline-block', verticalAlign: 'middle' }} />
                            )}
                        </Typography>

                        {isDirty ?
                            <Button 
                                variant="contained" 
                                color="primary" 
                                onClick={handleSave}
                                disabled={!isDirty} // Дизейблим кнопку, если нет изменений
                            >
                                Сохранить
                            </Button> : null    
                        }
                        
                    </>
                )}
            </CardContent>
        </Card>

        <MoveToAnotherClassDialog 
            open={moveDialogOpen}
            onClose={()=>setMoveDialogOpen(false)}
        />
        </>
    )
};

export default StudentInfo;