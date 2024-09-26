import React from 'react';
import { Link, Outlet } from 'react-router-dom';


// export interface IBookAuthor {
//   id: string;
//   fullName: string
// }

// async function get() {
//   try{
//     const response: AxiosResponse<IBookAuthor[]> = await axios.get("https://localhost:7078/api/authors?partName=а")
//     console.log(response.data);
//   }
//   catch(error) {
//     console.log("error fetching: ", error)
//     throw error;
//   }
// }

const App: React.FC = () => {
  return (
    <div>
      <nav>
        <Link to="/">Home</Link>
        <Link to="/about">About</Link>
      </nav>
      <Outlet />
    </div>
  );
};

export default App;