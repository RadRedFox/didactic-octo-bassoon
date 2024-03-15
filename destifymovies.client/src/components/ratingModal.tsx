import { useContext } from 'react'

import { ModalContextContext } from '../contexts/modalContext'
import Modal from './modal'

interface IRatingModalProps {
    movieId: number
}

const RatingModal = ({
    movieId
}: IRatingModalProps) => {
    const { ratingModal } = useContext(ModalContextContext)
    const setRatingModalOpen = ratingModal[1]

    const handleSave = (data: FormData) => {
        console.log({ data, movieId })
    }

    return (
        <Modal
            title="Add Rating"
            formFields={(
                <>
                    <label htmlFor="source" className="input_wrapper">
                        <span className="input_label">Source</span>
                        <input id="source" className="input_input" name="source" type="text" />
                    </label>
                    <label htmlFor="score" className="input_wrapper">
                        <span className="input_label">Score</span>
                        <input id="score" className="input_input" name="score" type="number" min="0" max="100" />
                    </label>
                </>
            )}
            setModalOpen={setRatingModalOpen}
            handleModalSave={handleSave}
        />
    )
}

export default RatingModal
