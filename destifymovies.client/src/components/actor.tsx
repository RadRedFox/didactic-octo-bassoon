import {
    useContext,
    useEffect,
    useState
} from 'react'

import { GlobalStateContext } from '../contexts/globalState'
//import { ModalContextContext } from '../contexts/modalContext'
import { type Actor, getActor } from '../lib'

const FullActor = () => {
    const {
        activeActor,
        setActiveMovie
    } = useContext(GlobalStateContext)
    //const { movieModal } = useContext(ModalContextContext)
    const [actor, setActor] = useState<Actor | null>(null)
    //const setMovieModalOpen = movieModal[1]

    useEffect(() => {
        const controller = new AbortController()

        activeActor !== null && getActor(activeActor)
            .then((data) => setActor(data))

        return () => {
            controller.abort()
        }
    }, [activeActor])

    return (
        <section>
            {actor && (
                <>
                    <h2>{`${actor.firstName}${actor.lastName ? ` ${actor.lastName}` : ''}`}</h2>
                    {actor.movies && (
                        <div>
                            <div>
                                <h3>Movies</h3>
                                {/*<button onClick={() => setMovieModalOpen(true)}>Add Movie</button>*/}
                            </div>
                            <ul className="table">
                                <li className="table_row">
                                    <span className="table_cell">Movie Title</span>
                                </li>
                                {actor.movies.map((movie) => (
                                    <li key={movie.id} className="table_row">
                                        <button className="table_cell" onClick={() => setActiveMovie(movie.id)}>
                                            {movie.title}
                                        </button>
                                        {/*<button className="table_cell" onClick={() => { }}>Remove</button>*/}
                                    </li>
                                ))}
                            </ul>
                        </div>
                    )}
                </>
            )}
        </section>
    )
}

export default FullActor
