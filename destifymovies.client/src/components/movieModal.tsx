import { useContext } from 'react'

import { GlobalStateContext } from '../contexts/globalState'
import { ModalContextContext } from '../contexts/modalContext'
import Modal from './modal'
import { addMovie } from '../lib'

//interface IMovieModalProps {
//    actorId?: number
//}

const MovieModal = () => {
    const {
        setMovies
    } = useContext(GlobalStateContext)
    const { movieModal } = useContext(ModalContextContext)
    const setMovieModalOpen = movieModal[1]

    const handleSave = async (data: FormData) => {
        const title = (data.get('title') as string ?? '').trim()

        if (!title || !title.length) return

        const newMovie = await addMovie({ title })

        if (newMovie) {
            setMovies([newMovie], false)
            setMovieModalOpen(false)
            return
        }

        console.warn('Problem saving movie')
    }

    return (
        <Modal
            title="Add Movie"
            formFields={(
                <>
                    <label htmlFor="title" className="input_wrapper">
                        <span className="input_label">Title</span>
                        <input id="title" className="input_input" name="title" type="text" />
                    </label>
                </>
            )}
            setModalOpen={setMovieModalOpen}
            handleModalSave={handleSave}
        />
    )
}

export default MovieModal
