import React, { useState, useEffect } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  TextField,
  Snackbar,
  Alert,
  IconButton,
} from '@mui/material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import ArrowForwardIcon from '@mui/icons-material/ArrowForward';
import UndoIcon from '@mui/icons-material/Undo';

const MyDialog = () => {
  const [open, setOpen] = useState(true);
  const [title, setTitle] = useState<string>('');
  const [author, setAuthor] = useState<string>('');
  const [year, setYear] = useState<string>('');
  const [series, setSeries] = useState<string>('');
  const [similarBooks, setSimilarBooks] = useState<{ id: number; title: string; author: string; year: string; series: string }[]>([]);
  const [loading, setLoading] = useState(false);
  const [snackbarOpen, setSnackbarOpen] = useState(false);
  const [currentBookIndex, setCurrentBookIndex] = useState<number | null>(null);
  const [searching, setSearching] = useState<boolean>(false);
  const [previousValues, setPreviousValues] = useState<{ title: string; author: string; year: string; series: string } | null>(null);

  const fetchSimilarBooks = async () => {
    setLoading(true);
    setTimeout(() => {
      const allBooks = [
        { id: 1, title: 'The Great Gatsby', author: 'F. Scott Fitzgerald', year: '1925', series: 'Classic' },
        { id: 2, title: '1984', author: 'George Orwell', year: '1949', series: 'Dystopian' },
        { id: 3, title: 'To Kill a Mockingbird', author: 'Harper Lee', year: '1960', series: 'Classic' },
        { id: 4, title: 'Brave New World', author: 'Aldous Huxley', year: '1932', series: 'Dystopian' },
        { id: 5, title: 'The Catcher in the Rye', author: 'J.D. Salinger', year: '1951', series: 'Classic' },
      ];

      const filteredBooks = allBooks.filter(book => {
        return (
          (!title || book.title.toLowerCase().includes(title.toLowerCase())) &&
          (!author || book.author.toLowerCase().includes(author.toLowerCase())) &&
          (!year || book.year.includes(year)) &&
          (!series || book.series?.toLowerCase().includes(series.toLowerCase()))
        );
      });

      setSimilarBooks(filteredBooks);
      setLoading(false);
      if (filteredBooks.length > 0) {
        setSnackbarOpen(true);
        setCurrentBookIndex(0);
      }
    }, 1000);
  };

  useEffect(() => {
    if (searching) {
      setPreviousValues({ title, author, year, series }); // Сохраняем текущее состояние
      fetchSimilarBooks();
      setSearching(false);
    }
  }, [searching]);

  const handleInputChange = () => {
    setSearching(true);
  };

  const handleSnackbarClose = () => {
    setSnackbarOpen(false);
  };

  const handleSelectBook = () => {
    if (currentBookIndex !== null) {
      const selectedBook = similarBooks[currentBookIndex];
      updateFields(selectedBook);
    }
  };

  const updateFields = (book: { title: string; author: string; year: string; series: string }) => {
    setTitle(book.title);
    setAuthor(book.author);
    setYear(book.year);
    setSeries(book.series);
  };

  const handleNextBook = () => {
    if (currentBookIndex !== null && currentBookIndex < similarBooks.length - 1) {
      const nextIndex = currentBookIndex + 1;
      setCurrentBookIndex(nextIndex);
      updateFields(similarBooks[nextIndex]); // Обновляем поля ввода
    }
  };

  const handlePreviousBook = () => {
    if (currentBookIndex !== null && currentBookIndex > 0) {
      const prevIndex = currentBookIndex - 1;
      setCurrentBookIndex(prevIndex);
      updateFields(similarBooks[prevIndex]); // Обновляем поля ввода
    }
  };

  const handleCreateBook = () => {
    console.log("Создать книгу с данными:", { title, author, year, series });
  };

  const handleRevertToPrevious = () => {
    if (previousValues) {
      setTitle(previousValues.title);
      setAuthor(previousValues.author);
      setYear(previousValues.year);
      setSeries(previousValues.series);
      setSimilarBooks([]);
      setCurrentBookIndex(null);
    }
  };

  return (
    <Dialog open={open} onClose={() => setOpen(false)}>
      <DialogTitle>Введите данные о книге</DialogTitle>
      <DialogContent>
        <TextField
          margin="dense"
          label="Название"
          fullWidth
          variant="outlined"
          value={title}
          onChange={(e) => { setTitle(e.target.value); handleInputChange(); }}
        />
        <TextField
          margin="dense"
          label="Автор"
          fullWidth
          variant="outlined"
          value={author}
          onChange={(e) => { setAuthor(e.target.value); handleInputChange(); }}
        />
        <TextField
          margin="dense"
          label="Год издания"
          fullWidth
          variant="outlined"
          value={year}
          onChange={(e) => { setYear(e.target.value); handleInputChange(); }}
        />
        <TextField
          margin="dense"
          label="Серия издания"
          fullWidth
          variant="outlined"
          value={series}
          onChange={(e) => { setSeries(e.target.value); handleInputChange(); }}
        />
        
        {loading && <div>Загрузка...</div>}

        <Snackbar open={snackbarOpen} autoHideDuration={6000} onClose={handleSnackbarClose}>
          <Alert onClose={handleSnackbarClose} severity="info">
            Найдены похожие книги! Нажмите для просмотра.
            <Button onClick={handleSelectBook}>Посмотреть</Button>
          </Alert>
        </Snackbar>

        {similarBooks.length > 0 && (
          <div style={{ marginTop: '16px', display: 'flex', alignItems: 'center' }}>
            <IconButton onClick={handlePreviousBook} disabled={currentBookIndex === 0}>
              <ArrowBackIcon />
            </IconButton>
            {currentBookIndex !== null && (
              <div style={{ margin: '0 16px' }}>
                <strong>Текущая книга:</strong>
                <div>{similarBooks[currentBookIndex].title} by {similarBooks[currentBookIndex].author} ({similarBooks[currentBookIndex].year})</div>
              </div>
            )}
            <IconButton onClick={handleNextBook} disabled={currentBookIndex === similarBooks.length - 1}>
              <ArrowForwardIcon />
            </IconButton>
          </div>
        )}

        <Button onClick={handleRevertToPrevious} color="secondary" startIcon={<UndoIcon />} style={{ marginTop: '16px' }}>
          Вернуться к предыдущим данным
        </Button>

        <Button onClick={handleCreateBook} color="primary" style={{ marginTop: '16px' }}>
          Создать книгу
        </Button>
      </DialogContent>
      <DialogActions>
        <Button onClick={() => setOpen(false)} color="primary">
          Закрыть
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default MyDialog;
