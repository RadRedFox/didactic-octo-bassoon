import { useContext } from 'react'

import { ModalContextContext } from '../contexts/modalContext'
import Modal from './modal'
import { addActor } from '../lib'

//interface IActorModalProps {
//    movieId?: number
//}

const ActorModal = () => {
    const { actorModal } = useContext(ModalContextContext)
    const setActorModalOpen = actorModal[1]

    const handleSave = async (data: FormData) => {
        const firstName = (data.get('firstName') as string ?? '').trim()
        const lastName = (data.get('lastName') as string ?? '').trim()

        if (!firstName || !firstName.length) return

        const newActor = await addActor({ firstName, lastName })

        if (newActor) {
            setActorModalOpen(false)
            return
        }

        console.warn('Problem saving actor')
    }

    return (
        <Modal
            title="Add Actor"
            formFields={(
                <>
                    <label htmlFor="firstName" className="input_wrapper">
                        <span className="input_label">First name</span>
                        <input id="firstName" className="input_input" name="firstName" type="text" />
                    </label>
                    <label htmlFor="lastName" className="input_wrapper">
                        <span className="input_label">Last name</span>
                        <input id="lastName" className="input_input" name="lastName" type="text" />
                    </label>
                </>
            )}
            setModalOpen={setActorModalOpen}
            handleModalSave={handleSave}
        />
    )
}

export default ActorModal
