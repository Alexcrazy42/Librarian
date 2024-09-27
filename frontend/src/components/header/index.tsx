import React from 'react';
import { AppBar, Toolbar, Button } from '@mui/material';
import { Link } from 'react-router-dom';
import { RootState } from '@state/appStore';
import { useSelector } from 'react-redux';

const Header = () => {
  const id = useSelector((state: RootState) => state.counter.id);

    return (
      <>
      <AppBar position="static" className="bg-blue-600">
        <Toolbar className="flex justify-between">
          <div className="flex space-x-4">
            <Link to="/" className="text-white hover:text-gray-300">
              <Button color="inherit">Главная</Button>
            </Link>
            <Link to="/login" className="text-white hover:text-gray-300">
              <Button color="inherit">Войти</Button>
            </Link>
            <Link to="/registration" className="text-white hover:text-gray-300">
              <Button color="inherit">Регистрация</Button>
            </Link>
          </div>
        </Toolbar>
      </AppBar>
      </>
    );
  };
  
  export default Header;