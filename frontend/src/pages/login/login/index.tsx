import React, { useState } from 'react';
import { TextField, Button, Typography, Container, Paper } from '@mui/material';
import { useDispatch } from 'react-redux';
import { setLibrarianId } from '@state/appSlice';
import { useNavigate } from 'react-router-dom';

const Login: React.FC = () => {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [error, setError] = useState<string>('');
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogin = () => {
    if (username === '' || password === '') {
      setError('Пожалуйста, введите логин и пароль');
      
      return;
    }
    
    
    dispatch(setLibrarianId('123'));
    navigate('/')
  };

  return (
    <Container component="main" maxWidth="xs">
      <Paper elevation={3} className="p-6 mt-10">
        <Typography component="h1" variant="h5" className="text-center mb-4">
          Вход библиотекаря
        </Typography>
        {error && <Typography color="error" className="text-center mb-2">{error}</Typography>}
        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          label="Логин"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          label="Пароль"
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <Button
          fullWidth
          variant="contained"
          color="primary"
          onClick={handleLogin}
          className="mt-4"
        >
          Войти
        </Button>
      </Paper>
    </Container>
  );
};

export default Login;
