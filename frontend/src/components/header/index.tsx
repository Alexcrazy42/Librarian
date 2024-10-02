import React, { useEffect } from 'react';
import { AppBar, Toolbar, Button } from '@mui/material';
import { Link } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '@state/appStore';
import { useNavigate } from 'react-router-dom';
import { setLibrarianId } from '@state/appSlice';

const Header = () => {
  const librarianId = useSelector((state: RootState) => state.auth.librarianId);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    if(librarianId === '') {
      navigate('/login');
    }
  }, [])

  const logout = () => {
    dispatch(setLibrarianId(''));
    navigate('/login');
  }

  return (
    <AppBar position="static" className="bg-blue-600">
      <Toolbar className="flex justify-between">
        <div className="flex space-x-4">
          {librarianId != '' ? (
            <>
              {/* <Button color="inherit">{username}</Button> Имя пользователя */}
              <Link to="/" className="text-white hover:text-gray-300">
                <Button color="inherit">Главная</Button>
              </Link>
                <Button onClick={logout} color="inherit">Выйти</Button>
            </>
          ) : (
            <>
              <Link to="/login" className="text-white hover:text-gray-300">
                <Button color="inherit">Войти</Button>
              </Link>
              <Link to="/registration" className="text-white hover:text-gray-300">
                <Button color="inherit">Регистрация</Button>
              </Link>
            </>
          )}
        </div>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
