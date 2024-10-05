import { Button } from "@mui/material";
import { setLibrarianId } from "@state/appSlice";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";

const AuthHeader = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const logout = () => {
        dispatch(setLibrarianId(''));
        navigate('/login');
      }

    return(
        <>
            <Link to="/" className="text-white hover:text-gray-300">
                <Button color="inherit">Главная</Button>
            </Link>
            <Link to="/ed-books" className="text-white hover:text-gray-300">
                <Button color="inherit">Учебная литература</Button>
            </Link>
            <Button onClick={logout} color="inherit">Выйти</Button>
            </>
    )
}

export default AuthHeader;