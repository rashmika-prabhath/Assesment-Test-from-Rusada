import React, { useEffect, useState } from 'react'
import axios from 'axios';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import moment from 'moment'
import { Box, Drawer, Grid, Modal, Switch } from '@mui/material';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Swal from 'sweetalert2'
import AircraftRegistration from './AircraftRegistration';
import { jsonToFormData } from '../helpers/form_build'
import { useRouter } from 'next/router';

interface IAircraft {
    id: number,
    make: string,
    model: string,
    registration: string,
    location: string,
    dateTime: string,
    image: string,
    sighting: boolean
}

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 1000,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

export const AircraftList = () => {
    const [aircrafts, setAircrafts] = useState<IAircraft[]>([])
    const [open, setOpen] = React.useState(false);
    const [edit, setEdit] = React.useState(null);
    const router = useRouter()
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    useEffect(() => {
        axios.get(`https://localhost:44319/api/Aircraft`)
            .then(({ data }) => {
                console.log("res", data);
                setAircrafts(data)
            })
            .catch(err => {
                console.log("err", err);
                Swal.fire(err?.message, '', 'error')
            })
    }, [])

    const update = (id, aircraft) => {
        axios.put(`https://localhost:44319/api/Aircraft/${id}`, aircraft)
            .then(({ data }) => {
                console.log("res", data);
                Swal.fire("Succussfully update!", '', 'success')
            })
            .catch(err => {
                console.log("err", err);
                Swal.fire(err?.message, '', 'error')
            })
    }

    const deleteItem = (id) => {

        Swal.fire({
            title: 'Do you want to delete the item?',
            showCancelButton: true,
            confirmButtonText: 'Delete',
            denyButtonText: `Don't Delete`,
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                axios.delete(`https://localhost:44319/api/Aircraft/${id}`)
                    .then(({ data }) => {
                        console.log("res", data);
                        Swal.fire('Deleted!', '', 'success')
                        setAircrafts(data)
                    })
                    .catch(err => {
                        console.log("err", err);
                        Swal.fire(err?.message, '', 'error')
                    })

            } else if (result.isDenied) {
                Swal.fire('Item is not deleted', '', 'info')
            }
        })

    }

    const editRow = (id, e) => {
        const newAircraftList = aircrafts.map((item) => {
            if (item.id === id) {
                const updatedItem = {
                    ...item,
                    [e.target.name]: e.target.type === "checkbox" ? e.target.checked : e.target.value,
                };
                update(id, updatedItem)
                return updatedItem;
            }

            return item;
        });
        setAircrafts(newAircraftList);
    }

    return (
        <Grid container spacing={1} justifyContent="center">
            {aircrafts.map((row) => (
                <Grid xs={4} marginTop={1}>
                    <Card sx={{ maxWidth: 275 }}>
                        <CardMedia
                            component="img"
                            height="140"
                            image={`img/aircrafts/${row.image}`}
                            alt="green iguana"
                        />
                        <CardContent>
                            <Typography gutterBottom variant="h5" component="div">
                                {row.make}
                            </Typography>
                            <Typography variant="subtitle1" color="text.secondary">
                                Model: {row.model}
                            </Typography>
                            <Typography variant="subtitle2" color="text.secondary">
                                Registration: {row.registration}
                            </Typography>
                            {/* <Typography variant="body1" color="text.secondary">
                                Location: {row.location}
                            </Typography>
                            <Typography variant="body1" color="text.secondary">
                                Date & Time: {moment(row.dateTime).format("DD/MM/YYYY HH:mm")}
                            </Typography> */}
                            <Typography variant="body2" color="text.secondary">
                                Sighting: <Switch name='sighting' checked={row.sighting} onChange={(e) => editRow(row.id, e)} />
                            </Typography>
                        </CardContent>
                        <CardActions>
                            <Button disabled={!row?.sighting} size="small" onClick={e => { router.push(`/aircraft/${row?.id}`) }} color='info'>View</Button>
                            <Button size="small" onClick={e => { setEdit(row?.id), setOpen(true) }}>Edit</Button>
                            <Button onClick={e => deleteItem(row.id)} size="small" color='error'>Delete</Button>
                        </CardActions>
                    </Card>
                </Grid>
            ))}
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Edit Aircraft
                    </Typography>
                    <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                        <AircraftRegistration airCraftId={edit} />
                    </Typography>
                </Box>
            </Modal>
        </Grid>
    )
}
export default AircraftList;