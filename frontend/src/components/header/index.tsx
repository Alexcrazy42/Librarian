import React, { useEffect } from 'react';
import { AppBar, Toolbar } from '@mui/material';
import { RootState } from '@state/appStore';
import { useNavigate } from 'react-router-dom';
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
    <>
    <AppBar position="static" className="bg-blue-600 w-full">
            <Toolbar className="flex justify-between items-center">
                <div className="flex space-x-4">
                    {librarianId !== '' ? (
                        <AuthHeader />
                    ) : (
                        <NoAuthHeader />
                    )}
                </div>
            </Toolbar>
        </AppBar>
    </>
  );
};

export default Header;
