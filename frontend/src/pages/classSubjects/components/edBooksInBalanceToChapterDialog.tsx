import { Appointment, BookCondition, Language, Level } from "@interfaces/interfaces";
import { EdBookInBalanceResponse } from "@interfaces/responses/edBooksResponses";
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, List, ListItem, ListItemText } from "@mui/material";

const edBooksInBalance: EdBookInBalanceResponse[] = [
    {
        id: "1",
        baseEdBook: {
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
        price: 29.99,
        condition: BookCondition.New,
        year: 2023,
        note: "A great start for beginners.",
        inPlaceCount: 10,
        totalCount: 50,
        supplyId: "supply1",
        groundId: "ground1",
        inStock: true
    },
    {
        id: "2",
        baseEdBook: {
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
        price: 39.99,
        condition: BookCondition.New,
        year: 2023,
        note: "Deep dive into JavaScript.",
        inPlaceCount: 5,
        totalCount: 25,
        supplyId: "supply2",
        groundId: "ground2",
        inStock: true
    },
    {
        id: "3",
        baseEdBook: {
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
        price: 49.99,
        condition: BookCondition.Dilapidated,
        year: 2021,
        note: "Essential for computer science students.",
        inPlaceCount: 2,
        totalCount: 15,
        supplyId: "supply3",
        groundId: "ground3",
        inStock: false
    },
    {
        id: "4",
        baseEdBook: {
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
        price: 25.00,
        condition: BookCondition.New,
        year: 2023,
        note: "Learn the basics of web development.",
        inPlaceCount: 8,
        totalCount: 40,
        supplyId: "supply4",
        groundId: "ground4",
        inStock: true
    },
    {
        id: "5",
        baseEdBook: {
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
        price: 45.50,
        condition: BookCondition.New,
        year: 2022,
        note: "Introduction to ML concepts.",
        inPlaceCount: 6,
        totalCount: 30,
        supplyId: "supply5",
        groundId: "ground5",
        inStock: true
    },
    {
        id: "6",
        baseEdBook: {
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
        price: 35.00,
        condition: BookCondition.Dilapidated,
        year: 2020,
        note: "A comprehensive guide to databases.",
        inPlaceCount: 4,
        totalCount: 20,
        supplyId: "supply6",
        groundId: "ground6",
        inStock: false
    },
    {
        id: "7",
        baseEdBook: {
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
        price: 28.75,
        condition: BookCondition.New,
        year: 2023,
        note: "Start your journey in cybersecurity.",
        inPlaceCount: 10,
        totalCount: 50,
        supplyId: "supply7",
        groundId: "ground7",
        inStock: true
    },
    {
        id: "8",
        baseEdBook: {
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
        price: 55.00,
        condition: BookCondition.New,
        year: 2023,
        note: "Explore the basics of AI.",
        inPlaceCount: 3,
        totalCount: 15,
        supplyId: "supply8",
        groundId: "ground8",
        inStock: true
    },
    {
        id: "9",
        baseEdBook: {
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
        price: 60.00,
        condition: BookCondition.New,
        year: 2023,
        note: "Develop mobile applications.",
        inPlaceCount: 1,
        totalCount: 10,
        supplyId: "supply9",
        groundId: "ground9",
        inStock: false
    },
    {
        id: "10",
        baseEdBook: {
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
        price: 48.00,
        condition: BookCondition.New,
        year: 2023,
        note: "Understand cloud computing.",
        inPlaceCount: 7,
        totalCount: 35,
        supplyId: "supply10",
        groundId: "ground10",
        inStock: true
    },
    {
        id: "11",
        baseEdBook: {
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
        price: 30.00,
        condition: BookCondition.New,
        year: 2023,
        note: "Learn effective marketing strategies.",
        inPlaceCount: 8,
        totalCount: 40,
        supplyId: "supply11",
        groundId: "ground11",
        inStock: true
    },
    {
        id: "12",
        baseEdBook: {
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
        price: 40.00,
        condition: BookCondition.New,
        year: 2023,
        note: "Fundamentals of economics.",
        inPlaceCount: 5,
        totalCount: 25,
        supplyId: "supply12",
        groundId: "ground12",
        inStock: true
    }
]


const EdBooksInBalanceToChapterDialog: React.FC<{ open: boolean; onClose: () => void;}> = ({ open, onClose }) => {
    return(
        <>
            <Dialog open={open} onClose={onClose}>
                <DialogTitle>Связанные книжки</DialogTitle>
                <DialogContent>
                    <List>
                        {edBooksInBalance.map(book => (
                            <ListItem key={book.id}>
                                <ListItemText
                                    primary={book.baseEdBook.title}
                                    secondary={`Цена: ${book.price}Р, Условия: ${book.condition}, Количество: ${book.inPlaceCount}, Год: ${book.year}`}
                                />
                            </ListItem>
                        ))}
                    </List>
                </DialogContent>
                <DialogActions>
                    <Button onClick={onClose} color="primary">Выйти</Button>
                </DialogActions>
            </Dialog>
        </>
    )
}

export default EdBooksInBalanceToChapterDialog;