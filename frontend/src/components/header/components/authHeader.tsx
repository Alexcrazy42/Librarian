import { Button, Menu, MenuItem } from "@mui/material";
import { setLibrarianId } from "@state/appSlice";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";

const AuthHeader = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const [reportEl, setReportEl] = useState(null);

    const handleReportButtonClick = (event) => {
        setReportEl(event.currentTarget);
    };

    const handleReportButtonClose = () => {
        setReportEl(null);
    };


    const logout = () => {
        dispatch(setLibrarianId(''));
        navigate('/login');
    };

    return(
        <div className="flex justify-between items-center w-full">
    <div className="flex space-x-4">
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
        <Button
            aria-controls="simple-menu"
            aria-haspopup="true"
            onClick={handleReportButtonClick}
            color="inherit"
        >
            Отчёты
        </Button>
    </div>
    <Button onClick={logout} color="inherit">Выйти</Button>
</div>
    )
}

export default AuthHeader;