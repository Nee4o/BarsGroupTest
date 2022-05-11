import React, {useState} from "react";

export default function App() {
    const [heroes, setHeroes] = useState([]);
    function getHeroes() {
        const url = 'https://localhost:7213/Get';
        fetch(url,{
            method:'GET'
        })
            .then(response => response.json())
            .then(heroesFromServer => {
                console.log((heroesFromServer));
                setHeroes(heroesFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    }
  return (
    <div>
        <div>
            <button onClick={getHeroes}> Get heroes from server</button>
        </div>
        {renderPostsTable()}
    </div>
  );
}

function renderPostsTable(){
  return(
      <div>
          <table>
              <thead>
              <tr>
                  <th>Id (PK)</th>
                  <th>FirstName</th>
                  <th>LastName</th>
                  <th>HeroName</th>
                  <th>CRUD Operations</th>
              </tr>
              </thead>
          </table>

      </div>
  );
}