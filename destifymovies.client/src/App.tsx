import {
    useEffect,
    useState
} from 'react'

import MovieList from './components/movieList'
import FullMovie from './components/movie'
import FullActor from './components/actor'
import ActionBar from './components/actionBar'
import GlobalState from './contexts/globalState'
import ModalContext, { type IModalContext } from './contexts/modalContext'
import MovieModal from './components/movieModal'
import ActorModal from './components/actorModal'
import RatingModal from './components/ratingModal'
import {
    getActors,
    getMovies,
    type Actor,
    type Movie,
    type Rating
} from './lib'

import './App.css'

const App = () => {
    const [movies, setMoviesState] = useState<Movie[]>([])
    const [actors, setActorsState] = useState<Actor[]>([])
    const [ratings, setRatingsState] = useState<Rating[]>([])
    const [activeMovie, setActiveMovieState] = useState<number | null>(null)
    const [activeActor, setActiveActorState] = useState<number | null>(null)
    const [movieModalOpen, setMovieModalOpen] = useState(false)
    const [actorModalOpen, setActorModalOpen] = useState(false)
    const [ratingModalOpen, setRatingModalOpen] = useState(false)

    useEffect(() => {
        const controller = new AbortController()

        getMovies(controller)
            .then(data => setMovies(data))

        return () => {
            controller.abort()
        }
    }, [])

    useEffect(() => {
        const controller = new AbortController()

        getActors(controller)
            .then(data => setActors(data))

        return () => {
            controller.abort()
        }
    }, [])

    const setActiveMovie = (id: number) => {
        setActiveActorState(null)
        setActiveMovieState(id)
    }

    const setActiveActor = (id: number) => {
        setActiveMovieState(null)
        setActiveActorState(id)
    }

    const clearActive = () => {
        setActiveMovieState(null)
        setActiveActorState(null)
    }

    const setMovies = (moviesData: Movie[], overwrite = true) => {
        if (overwrite) {
            setMoviesState(moviesData)

            return
        }

        setMoviesState([...movies, ...moviesData])
    }

    const setActors = (actorsData: Actor[]) => {
        setActorsState(actorsData)
    }

    const setRatings = (ratingsData: Rating[]) => {
        setRatingsState(ratingsData)
    }

    const globalStateValue = {
        movies,
        setMovies,
        actors,
        setActors,
        ratings,
        setRatings,
        activeMovie,
        setActiveMovie,
        activeActor,
        setActiveActor
    }

    const openMovieModal = (state: boolean) => {
        setActorModalOpen(false)
        setRatingModalOpen(false)
        setMovieModalOpen(state)
    }

    const openActorModal = (state: boolean) => {
        setRatingModalOpen(false)
        setMovieModalOpen(false)
        setActorModalOpen(state)
    }

    const openRatingModal = (state: boolean) => {
        setActorModalOpen(false)
        setMovieModalOpen(false)
        setRatingModalOpen(state)
    }

    const modalContextProps: IModalContext = {
        movieModal: [movieModalOpen, openMovieModal],
        actorModal: [actorModalOpen, openActorModal],
        ratingModal: [ratingModalOpen, openRatingModal]
    }

    return (
        <>
            <GlobalState value={globalStateValue}>
                <ModalContext value={modalContextProps}>
                    <nav className="nav_wrapper">
                        <h1 className="nav_title">
                            <span onClick={() => clearActive()}>
                                Destify Movies
                            </span>
                        </h1>
                        <ActionBar />
                    </nav>
                    <main>
                        {activeMovie !== null && (
                            <FullMovie />
                        )}
                        {activeActor !== null && (
                            <FullActor />
                        )}
                        {activeMovie === null && activeActor === null && (
                            <MovieList />
                        )}
                    </main>
                    {movieModalOpen && (<MovieModal />)}
                    {actorModalOpen && (<ActorModal />)}
                    {activeMovie !== null && ratingModalOpen && (<RatingModal movieId={activeMovie} />)}
                </ModalContext>
            </GlobalState>
        </>
    )
}

export default App
