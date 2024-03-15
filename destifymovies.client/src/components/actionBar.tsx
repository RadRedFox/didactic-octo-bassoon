import { useContext } from 'react'

import { ModalContextContext } from '../contexts/modalContext'
import SearchBar from './searchBar'

import './actionBar.css'

const ActionBar = () => {
    const {
        movieModal,
        actorModal
    } = useContext(ModalContextContext)
    const setMovieModalOpen = movieModal[1]
    const setActorModalOpen = actorModal[1]

    return (
        <>
            <div className="actionbar_wrapper">
                <SearchBar />

                <div className="button_group">
                    <button className="button" onClick={() => setMovieModalOpen(true)}>+ Movie</button>
                    <button className="button" onClick={() => setActorModalOpen(true)}>+ Actor</button>
                </div>
            </div>
        </>
    )
}

export default ActionBar
