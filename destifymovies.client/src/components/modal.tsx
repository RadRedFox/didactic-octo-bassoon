import React, { useRef } from 'react'

import './modal.css'

interface IModalProps {
    title: string
    formFields: React.ReactNode
    setModalOpen: (state: boolean) => void
    handleModalSave: (data: FormData) => void
}

const Modal = ({
    title,
    formFields,
    setModalOpen,
    handleModalSave
}: IModalProps) => {
    const formRef = useRef<HTMLFormElement>(null)

    const handleSave = async () => {
        if (formRef?.current) await handleModalSave(new FormData(formRef.current))
    }

    return (
        <div className="modal_wrapper">
            <div className="modal paper">
                <div className="modal_header">
                    <h2>{title}</h2>
                    <button onClick={() => setModalOpen(false)}>X</button>
                </div>
                <form className="modal_body" ref={formRef}>
                    {formFields}
                </form>
                <div className="modal_footer">
                    <button onClick={() => setModalOpen(false)}>Cancel</button>
                    <button onClick={() => handleSave()}>Save</button>
                </div>
            </div>
        </div>
    )
}

export default Modal
