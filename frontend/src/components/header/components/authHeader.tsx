import { Button, Menu, MenuItem } from "@mui/material";
import { setLibrarianId } from "@state/appSlice";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";

const AuthHeader = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const logout = () => {
        dispatch(setLibrarianId(''));
        navigate('/login');
    };

    return(
        <div className="flex justify-between items-center w-full bg-gray-800 p-4">
            <Link to="/" className="text-white hover:text-gray-300">
                <Button color="inherit">Главная</Button>
            </Link>
            <Link to="/ed-books" className="text-white hover:text-gray-300">
                <Button color="inherit">Учебная литература</Button>
            </Link>
            <Link to="/supplies" className="text-white hover:text-gray-300">
                <Button color="inherit">Поставки</Button>
            </Link>
            <Link to="/class-subjects" style={{ textDecoration: 'none' }}>
                <Button color="inherit">Предметы</Button>
            </Link>

            <Button onClick={logout} color="inherit">Выйти</Button>
        </div>

    )
}

export default AuthHeader;