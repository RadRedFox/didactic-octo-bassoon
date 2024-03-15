import {
    useContext,
    useEffect,
    useState
} from 'react'

import { GlobalStateContext } from '../contexts/globalState'
import { ModalContextContext } from '../contexts/modalContext'
import { type Movie, getMovie } from '../lib'

const FullMovie = () => {
    const {
        activeMovie,
        setActiveActor
    } = useContext(GlobalStateContext)
    const {
        //actorModal,
        ratingModal
    } = useContext(ModalContextContext)
    const [movie, setMovie] = useState<Movie | null>(null)
    //const setActorModalOpen = actorModal[1]
    const setRatingModalOpen = ratingModal[1]

    useEffect(() => {
        const controller = new AbortController()

        activeMovie !== null && getMovie(activeMovie)
            .then((data) => setMovie(data))

        return () => {
            controller.abort()
        }
    }, [activeMovie])

    return (
        <section>
            {movie && (
                <>
                    <h2>{movie?.title}</h2>
                    {movie.actors && movie.actors.length > 0 && (
                        <div>
                            <div>
                                <h3>Actors</h3>
                                {/*<button onClick={() => setActorModalOpen(true)}>Add Actor</button>*/}
                            </div>
                            <ul className="table">
                                <li className="table_row">
                                    <span className="table_cell">Actor Name</span>
                                </li>
                                {movie.actors.map((actor) => (
                                    <li key={actor.id} className="table_row">
                                        <button className="table_cell" onClick={() => setActiveActor(actor.id)}>
                                            {`${actor.firstName}${actor.lastName ? ` ${actor.lastName}` : ''}`}
                                        </button>
                                        {/*<button className="table_cell" onClick={() => { }}>Remove</button>*/}
                                    </li>
                                ))}
                            </ul>
                        </div>

                    )}
                    {movie.ratings && movie.ratings.length > 0 && (
                        <div>
                            <div>
                                <h3>Ratings</h3>
                                <button onClick={() => setRatingModalOpen(true)}>Add Rating</button>
                            </div>
                            <ul className="table">
                                <li className="table_row">
                                    <span className="table_cell">Source</span>
                                    <span className="table_cell">Score</span>
                                </li>
                                {movie.ratings.map((rating) => (
                                    <li key={rating.id} className="table_row">
                                        <span className="table_cell">{rating.source}</span>
                                        <span className="table_cell">{rating.score}/100</span>
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

export default FullMovie
