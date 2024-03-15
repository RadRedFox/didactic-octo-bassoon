import { useContext } from 'react'

import { GlobalStateContext } from '../contexts/globalState'
//import { removeMovie } from '../lib/movies'

const MovieList = () => {
    const {
        movies,
        //setMovies,
        setActiveMovie
    } = useContext(GlobalStateContext)

    //const removeClickHandler = async (id: number, index: number) => {
    //    await removeMovie(id)

    //    const tempMovies = [...movies]

    //    tempMovies.splice(index, 1)
    //    setMovies(tempMovies)
    //}

    return (
        <section>
            <ul className="table">
                <li className="table_row">
                    <span className="table_cell">Movie Title</span>
                </li>
                {movies.map((movie) => (
                    <li key={movie.id} className="table_row">
                        <button className="table_cell" onClick={() => setActiveMovie(movie.id)}>
                            {movie.title}
                        </button>
                        {/*<button className="table_cell" onClick={() => removeClickHandler(movie.id, index)}>Remove</button>*/}
                    </li>
                ))}
            </ul>
        </section>
    )
}

export default MovieList
