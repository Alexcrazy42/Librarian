import { useParams } from "react-router-dom";

const Employee: React.FC = () => {
    const { id } = useParams();
    
    return(
        <div>
            <h1>Работник с ID: {id}</h1>
        </div>
    )
}

export default Employee;