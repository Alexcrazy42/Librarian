import { Button } from "@mui/material";
import { Link } from "react-router-dom";

const NoAuthHeader = () => {
    return(
        <>
              <Link to="/login" className="text-white hover:text-gray-300">
                <Button color="inherit">Войти</Button>
              </Link>
              <Link to="/registration" className="text-white hover:text-gray-300">
                <Button color="inherit">Регистрация</Button>
              </Link>
            </>
    )
}

export default NoAuthHeader;