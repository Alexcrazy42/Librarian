import React, { useEffect } from 'react';
import { AppBar, Toolbar, Button } from '@mui/material';
import { Link } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '@state/appStore';
import { useNavigate } from 'react-router-dom';
import { setLibrarianId } from '@state/appSlice';
import AuthHeader from './components/authHeader';
import NoAuthHeader from './components/noAuthHeader';

const Header = () => {
  const librarianId = useSelector((state: RootState) => state.auth.librarianId);
  const navigate = useNavigate();

  useEffect(() => {
    if(librarianId === '') {
      navigate('/login');
    }
  }, [])

  return (
    <AppBar position="static" className="bg-blue-600">
      <Toolbar className="flex justify-between">
        <div className="flex space-x-4">
          {librarianId != '' ? (
            <AuthHeader />
          ) : (
            <NoAuthHeader />
          )}
        </div>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
