import { Appointment, getAppointmentName, getLanguageName, getLevelName, Language, Level } from "@interfaces/interfaces";
import { BaseEdBookResponse } from "@interfaces/responses/edBooksResponses";
import { Alert, Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, getAppBarUtilityClass, InputLabel, MenuItem, Select, Snackbar, TextField } from "@mui/material";
import { useEffect, useState } from "react";


const baseEdBooks: BaseEdBookResponse[] = [
    {
        id: "1",
        title: "Introduction to Programming",
        publishingSeries: 101,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 1,
        startClass: 1,
        endClass: 10
    },
    {
        id: "2",
        title: "Advanced JavaScript",
        publishingSeries: 102,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 5,
        startClass: 11,
        endClass: 20
    },
    {
        id: "3",
        title: "Data Structures and Algorithms",
        publishingSeries: 103,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 3,
        startClass: 21,
        endClass: 30
    },
    {
        id: "4",
        title: "Web Development Essentials",
        publishingSeries: 104,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 2,
        startClass: 31,
        endClass: 40
    },
    {
        id: "5",
        title: "Machine Learning Basics",
        publishingSeries: 105,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 4,
        startClass: 41,
        endClass: 50
    },
    {
        id: "6",
        title: "Understanding Databases",
        publishingSeries: 106,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 3,
        startClass: 51,
        endClass: 60
    },
    {
        id: "7",
        title: "Cybersecurity Fundamentals",
        publishingSeries: 107,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 1,
        startClass: 61,
        endClass: 70
    },
    {
        id: "8",
        title: "Introduction to Artificial Intelligence",
        publishingSeries: 108,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 2,
        startClass: 71,
        endClass: 80
    },
    {
        id: "9",
        title: "Mobile App Development",
        publishingSeries: 109,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 5,
        startClass: 81,
        endClass: 90
    },
    {
        id: "10",
        title: "Cloud Computing Principles",
        publishingSeries: 110,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 4,
        startClass: 91,
        endClass: 100
    },
    {
        id: "11",
        title: "Digital Marketing Strategies",
        publishingSeries: 111,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 1,
        startClass: 101,
        endClass: 110
    },
    {
        id: "12",
        title: "Principles of Economics",
        publishingSeries: 112,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 3,
        startClass: 111,
        endClass: 120
    },
    {
        id: "13",
        title: "Graphic Design Basics",
        publishingSeries: 113,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 2,
        startClass: 121,
        endClass: 130
    },
    {
        id: "14",
        title: "Business Analytics",
        publishingSeries: 114,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 5,
        startClass: 131,
        endClass: 140
    },
    {
        id: "15",
        title: "Software Engineering Principles",
        publishingSeries: 115,
        language: Language.English,
        level: Level.Advanced,
        appointment: Appointment.Allowance,
        chapter: 4,
        startClass: 141,
        endClass: 150
    }
];

const AttachBaseEdBookToChapterDialog: React.FC<{ open: boolean; onClose: () => void; onSubmit: () => void}> = ({ open, onClose, onSubmit }) => {
    const [title, setTitle] = useState<string | null>(null);
    const [startClass, setStartClass] = useState<number | null>(null);
    const [endClass, setEndClass] = useState<number | null>(null);
    const [chapter, setChapter] = useState<number | null>(null);
    const [publishingSeries, setPublishingSeries] = useState<number | null>(null);
    const [language, setLanguage] = useState<Language | null>(null);
    const [appointment, setAppointment] = useState<Appointment | null>(null);
    const [level, setLevel] = useState<Level | null>(null);
    const [familiarBaseBooks, setFamiliarBooks] = useState<BaseEdBookResponse[]>();
    const [findFamiliarBooks, setFindFamiliarBooks] = useState<boolean>(false);
    const [alertToFindFamiliarBookOpen, setAlertToFindFamiliarBookOpen] = useState<boolean>(false);
    const [currentBookIndex, setCurrentBookIndex] = useState<number | null>(null);

    const fetchFamiliars = () => {
        setFamiliarBooks(baseEdBooks);
    };

    const handleSnackbarClose = () => {
        setAlertToFindFamiliarBookOpen(false);
    };

    const updateFields = (baseEdBook: BaseEdBookResponse) => {
        setTitle(baseEdBook.title);
        setStartClass(baseEdBook.startClass);
        setEndClass(baseEdBook.endClass);
        setChapter(baseEdBook.chapter);
        setPublishingSeries(baseEdBook.publishingSeries);
        setLanguage(baseEdBook.language);
        setAppointment(baseEdBook.appointment);
        setLevel(baseEdBook.level);
    }

    const handleSelectBook = () => {
        if (currentBookIndex !== null) {
          const selectedBook = familiarBaseBooks[currentBookIndex];
          updateFields(selectedBook);
        }
      };

    useEffect(() => {
        fetchFamiliars();
    }, [title, startClass, endClass, chapter, publishingSeries, language, appointment, level])


    return(
        <>
            <Dialog open={open} onClose={onClose}>
                <DialogTitle>Привязать книжку</DialogTitle>
                <DialogContent>
                    <TextField
                        label="Название"
                        variant="outlined"
                        fullWidth 
                        value={title}
                        onChange={(event) => setTitle(event.target.value)}
                        margin="normal"
                    />
                    <TextField
                        label="Стартовый класс"
                        type="number"
                        variant="outlined"
                        fullWidth
                        value={startClass}
                        onChange={(event) => setStartClass(Number(event.target.value))}
                        margin="normal"
                    />
                    <TextField
                        label="Конечный класс"
                        type="number"
                        variant="outlined"
                        fullWidth
                        value={endClass}
                        onChange={(event) => setEndClass(Number(event.target.value))}
                        margin="normal"
                    />

                    <TextField
                        label="Глава"
                        type="number"
                        variant="outlined"
                        fullWidth
                        value={chapter}
                        onChange={(event) => setChapter(Number(event.target.value))}
                        margin="normal"
                    />

                    <TextField
                        label="Серия издания"
                        type="number"
                        variant="outlined"
                        fullWidth
                        value={publishingSeries}
                        onChange={(event) => setPublishingSeries(Number(event.target.value))}
                        margin="normal"
                    />

                    <FormControl fullWidth margin="normal">
                        <InputLabel>Язык</InputLabel>
                        <Select
                            value={language}
                            onChange={event => {
                                setLanguage(event.target.value);
                            }}
                        >
                            {Object.values(Language)
                                .filter(value => typeof value === 'number') // Отбираем только числовые значения
                                .map(lang => (
                                    <MenuItem key={lang} value={lang}>
                                        {getLanguageName(lang)} {/* Текстовое представление языка */}
                                    </MenuItem>
                                ))}
                        </Select>
                    </FormControl>

                    <FormControl fullWidth margin="normal">
                        <InputLabel>Уровень</InputLabel>
                        <Select
                            value={level}
                            onChange={event => {
                                setLevel(event.target.value);
                            }}
                        >
                            {Object.values(Level)
                                .filter(value => typeof value === 'number')
                                .map(level => (
                                    <MenuItem key={level} value={level}>
                                        {getLevelName(level)}
                                    </MenuItem>
                                ))}
                        </Select>
                    </FormControl>

                    <FormControl fullWidth margin="normal">
                        <InputLabel>Предназначение</InputLabel>
                        <Select
                            value={appointment}
                            onChange={event => {
                                setAppointment(event.target.value);
                            }}
                        >
                            {Object.values(Appointment)
                                .filter(value => typeof value === 'number')
                                .map(appointment => (
                                    <MenuItem key={appointment} value={appointment}>
                                        {getAppointmentName(appointment)}
                                    </MenuItem>
                                ))}
                        </Select>
                    </FormControl>
                </DialogContent>
                <DialogActions>
                        <Button onClick={onClose} color="primary">Выйти</Button>
                        <Button onClick={onSubmit} color="primary">Привязать</Button>
                </DialogActions>
            </Dialog>

            <Snackbar open={alertToFindFamiliarBookOpen} autoHideDuration={6000} onClose={handleSnackbarClose}>
                <Alert onClose={handleSnackbarClose} severity="info">
                    Найдены похожие книги! Нажмите для просмотра.
                    <Button onClick={handleSelectBook}>Посмотреть</Button>
                </Alert>
            </Snackbar>
        </>
    )
}

export default AttachBaseEdBookToChapterDialog;