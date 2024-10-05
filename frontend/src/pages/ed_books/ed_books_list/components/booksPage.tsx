import React, { useState } from 'react';
import {
    Button,
    TextField,
    List,
    ListItem,
    ListItemText,
    Pagination,
    Typography,
    Container,
    Paper,
    Box,
    MenuItem,
    Select,
    InputLabel,
    FormControl,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import Filters from './filters';

interface Book {
    id: number;
    title: string;
    author: string;
}

// Функция для генерации случайных книг
const generateRandomBooks = (count: number): Book[] => {
    const titles = [
        '1984',
        'To Kill a Mockingbird',
        'The Great Gatsby',
        'Moby Dick',
        'War and Peace',
        'Pride and Prejudice',
        'The Catcher in the Rye',
        'Brave New World',
        'The Odyssey',
        'The Brothers Karamazov',
        'Crime and Punishment',
        'Jane Eyre',
        'Wuthering Heights',
        'The Picture of Dorian Gray',
        'Fahrenheit 451',
    ];

    const authors = [
        'George Orwell',
        'Harper Lee',
        'F. Scott Fitzgerald',
        'Herman Melville',
        'Leo Tolstoy',
        'Jane Austen',
        'J.D. Salinger',
        'Aldous Huxley',
        'Homer',
        'Fyodor Dostoevsky',
        'Charlotte Brontë',
        'Emily Brontë',
        'Oscar Wilde',
        'Ray Bradbury',
        'Virginia Woolf',
    ];

    const books: Book[] = [];
    for (let i = 0; i < count; i++) {
        const randomTitle = titles[Math.floor(Math.random() * titles.length)];
        const randomAuthor = authors[Math.floor(Math.random() * authors.length)];
        books.push({ id: i + 1, title: randomTitle, author: randomAuthor });
    }

    return books;
};

const booksData: Book[] = generateRandomBooks(100); // Генерация 100 случайных книг

const BooksPage: React.FC = () => {
    const [searchTerm, setSearchTerm] = useState<string>('');
    const [currentPage, setCurrentPage] = useState<number>(1);
    const [booksPerPage, setBooksPerPage] = useState<number>(5); // По умолчанию 5 книг на странице

    const filteredBooks = booksData.filter(book =>
        book.title.toLowerCase().includes(searchTerm.toLowerCase())
    );

    const totalPages = Math.ceil(filteredBooks.length / booksPerPage);
    const indexOfLastBook = currentPage * booksPerPage;
    const indexOfFirstBook = indexOfLastBook - booksPerPage;
    const currentBooks = filteredBooks.slice(indexOfFirstBook, indexOfLastBook);

    const handlePageChange = (event: React.ChangeEvent<unknown>, value: number) => {
        setCurrentPage(value);
    };

    const handleCreateBook = () => {
        console.log('Create new book');
    };

    return (
        <Container>
            <Box display="flex" justifyContent="space-between" alignItems="center" mt={2} mb={2}>
                
                <Filters searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
                <Button
                    variant="contained"
                    color="success"
                    onClick={handleCreateBook}
                    startIcon={<AddIcon />}
                    style={{ marginLeft: '16px', minWidth: '40px' }}
                />
            </Box>

            <Paper>
                <List>
                    {currentBooks.map(book => (
                        <ListItem key={book.id}>
                            <ListItemText primary={book.title} secondary={`Автор: ${book.author}`} />
                        </ListItem>
                    ))}
                </List>
            </Paper>

            <Box display="flex" justifyContent="space-between" alignItems="center" mt={2}>
                <Pagination
                    count={totalPages}
                    page={currentPage}
                    onChange={handlePageChange}
                    color="primary"
                />

                <FormControl variant="outlined" size="small">
                    <InputLabel>Книг на странице</InputLabel>
                    <Select
                        value={booksPerPage}
                        onChange={(e) => setBooksPerPage(Number(e.target.value))}
                        label="Книг на странице"
                    >
                        <MenuItem value={5}>5</MenuItem>
                        <MenuItem value={10}>10</MenuItem>
                        <MenuItem value={20}>20</MenuItem>
                        <MenuItem value={50}>50</MenuItem>
                    </Select>
                </FormControl>
            </Box>

            <Typography variant="body2" align="center" style={{ marginTop: '16px' }}>
                {`Всего книг: ${filteredBooks.length}`}
            </Typography>
        </Container>
    );
};

export default BooksPage;
