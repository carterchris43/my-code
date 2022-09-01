import React from 'react';
import PropTypes from 'prop-types';
import { Card, ListGroup, Button, Stack } from 'react-bootstrap';
import swal from 'sweetalert2';

function RenderContact(props) {

    const contact = {
        id: props.contact.id,
        name: props.contact.name,
        avatarUrl: props.contact.avatarUrl,
        email: props.contact.email,
        phone: props.contact.phone,
        notes: props.contact.notes,
        createdBy: props.contact.createdBy,
    };

    const onEditContactClicked = () => {
        props.setPageData((prevState)=>{
            let pd = {...prevState};
            pd.editData = contact;
            return pd;
        })
        props.toggleModal();
    };

    const onDeleteContactClicked = () => {
        swal.fire({
            title: 'Are you sure?',
            text: 'This contact will be deleted.',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Confirm Deletion',
            confirmButtonColor: '#d63030',
        }).then((result) => {
            if (result.isConfirmed) {
                props.deleteContact(contact.id);
            }
        });
    };

    const onEmailClicked = () => {
        swal.fire({
            title: 'Send email to:',
            text: contact.email,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Open email client',
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = `mailto:${contact.email}?subject=&body=`;
            }
        });
    };

    const openNotes = () => {
        if (contact.notes === '') {
            swal.fire({
                text: `No notes found, would you like to add notes for ${contact.name}?`,
                confirmButtonText: 'Add notes',
                showCancelButton: true,
            }).then((result) => {
                if (result.isConfirmed) {
                    onEditContactClicked();
                }
            });
        } else {
            swal.fire({
                title: `<p align="left">${contact.name} notes:`,
                html: `<p align="left">${contact.notes}</p>`,
                confirmButtonText: 'Edit notes',
                showCancelButton: true,
                cancelButtonText: 'Close',
            }).then((result) => {
                if (result.isConfirmed) {
                    onEditContactClicked();
                }
            });
        }
    };

    const onPhoneNumberClicked = () => {
        if (contact.phone !== '') {
            swal.fire({
                text: `Would you like to call ${contact.name}?`,
                icon: 'info',
                showCancelButton: true,
                confirmButtonText: `Dial ${formatPhoneNumber(contact.phone)}`,
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = `tel://${contact.phone}`;
                }
            });
        }
    };

    const formatPhoneNumber = (phoneNumberString) => {
        var cleaned = ('' + phoneNumberString).replace(/\D/g, '');
        var match = cleaned.match(/^(1|)?(\d{3})(\d{3})(\d{4})$/);
        if (match) {
            var intlCode = match[1] ? '+1 ' : '';
            return [intlCode, '(', match[2], ') ', match[3], '-', match[4]].join('');
        }
        return phoneNumberString;
    };

    return (
        <>
            <Card className="shadow mx-2 my-2" style={{ width: '20rem' }} id={contact.id}>
                <Card.Header>
                    <Stack direction="horizontal" gap={1}>
                        <Card.Img src={contact.avatarUrl} variant="top" className="avatar-md rounded-circle" />

                        <Button
                            onClick={onEditContactClicked}
                            className="btn btn-primary dripicons-document-edit ms-auto"></Button>
                        <Button onClick={onDeleteContactClicked} className="btn btn-danger dripicons-trash"></Button>
                    </Stack>
                </Card.Header>

                <Card.Body className>
                    <ListGroup variant="flush">
                        <ListGroup.Item>
                            <span className=" dripicons-user"> : </span>
                            {contact.name}
                        </ListGroup.Item>
                        <ListGroup.Item>
                            <span onClick={onPhoneNumberClicked} className="dripicons-phone">
                                {' '}
                                : {formatPhoneNumber(contact.phone)}
                            </span>
                        </ListGroup.Item>
                        <ListGroup.Item>
                            <span onClick={onEmailClicked} className="dripicons-mail">
                                {' '}
                                : {contact.email}
                            </span>
                        </ListGroup.Item>
                        <ListGroup.Item>
                            <button onClick={openNotes} className="btn btn-primary mb-2">
                                <i className="dripicons-pencil" /> Open Notes
                            </button>
                        </ListGroup.Item>
                    </ListGroup>
                </Card.Body>
            </Card>
        </>
    );
}

RenderContact.propTypes = {
    contact: PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string,
        avatarUrl: PropTypes.string,
        email: PropTypes.string.isRequired,
        phone: PropTypes.string,
        notes: PropTypes.string,
        createdBy: PropTypes.number,
    }),
    toggleModal: PropTypes.func.isRequired,
    deleteContact: PropTypes.func.isRequired,
    setPageData: PropTypes.func.isRequired,
};

export default RenderContact;

