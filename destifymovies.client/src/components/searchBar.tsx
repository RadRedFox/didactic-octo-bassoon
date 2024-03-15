import {
    useContext,
    useEffect,
    useRef,
    useState
} from 'react'

import { GlobalStateContext } from '../contexts/globalState'
import {
    type SearchResults,
    runSearch
} from '../lib'

import './searchbar.css'

const SearchBar = () => {
    const {
        activeActor,
        activeMovie,
        setActiveMovie,
        setActiveActor
    } = useContext(GlobalStateContext)
    const inputRef = useRef<HTMLInputElement | null>(null)
    const [searchResults, setSearchResults] = useState<SearchResults>({ movies: [], actors: [] })

    const clearSearchResults = (clearInput = true) => {
        setSearchResults({ movies: [], actors: [] })

        if (clearInput && inputRef.current) inputRef.current.value = ''
    }

    useEffect(() => {
        clearSearchResults()
    }, [activeActor, activeMovie])

    const handleInputChange = (value: string) => {
        const trimmedValue = value.trim()

        if (trimmedValue.length >= 2) {
            runSearch(trimmedValue)
                .then((data) => setSearchResults(data))
        } else {
            clearSearchResults(false)
        }
    }

    const handleMovieClick = (id: number) => {
        setActiveMovie(id)
        clearSearchResults()
    }

    const handleActorClick = (id: number) => {
        setActiveActor(id)
        clearSearchResults()
    }

    return (
        <label htmlFor="search" className="searchbar input_wrapper">
            <span className="input_label">Search</span>
            <input id="search" className="input_input" name="search" ref={inputRef} type="text" autoComplete="false" onChange={(e) => handleInputChange(e.target.value)} />
            {(searchResults.movies.length > 0 || searchResults.actors.length > 0) && (
                <div className="searchbar_results paper">
                    {searchResults.movies.length > 0 && (
                        <div className="searchbar_results_section">
                            <h4 className="searchbar_results_section-title">Movies</h4>
                            <ul className="table_wrapper">
                                {searchResults.movies.map((movie) => (
                                    <li key={movie.id} className="table_row">
                                        <button className="table_cell" onClick={() => handleMovieClick(movie.id)}>{movie.title}</button>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    )}
                    {(searchResults.movies.length > 0 && searchResults.actors.length > 0) && (
                        <hr className="searchbar_results_break" />
                    )}
                    {searchResults.actors.length > 0 && (
                        <div className="searchbar_results_section">
                            <h4 className="searchbar_results_section-title">Actors</h4>
                            <ul className="table_wrapper">
                                {searchResults.actors.map((actor) => (
                                    <li key={actor.id} className="table_row">
                                        <button className="table_cell" onClick={() => handleActorClick(actor.id)}>
                                            {`${actor.firstName}${actor.lastName ? ` ${actor.lastName}` : ''}`}
                                        </button>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    )}
                </div>
            )}
        </label>
    )
}

export default SearchBar
