
export default function modal({ children }) {
    return (
        <dialog open>
            <div className="modal__content">
                {children}
            </div>
        </dialog>
    );
}