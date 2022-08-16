import React, { useEffect, useState } from 'react'
import { Grid, FormControl, FormHelperText, FormLabel, TextField, InputLabel, Button, Switch, Box, Card, CardMedia, Input } from '@mui/material';
import { Formik } from 'formik';
import * as Yup from "yup";
import { useRouter } from 'next/router';
import axios from 'axios';
import moment from 'moment';
import Swal from 'sweetalert2'
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { jsonToFormData } from '../helpers/form_build'

export default function AircraftRegistration({ airCraftId = 0 }) {
    const [data, setData] = useState<any>([]);
    const [imagePreview, setImagePreview] = useState<any>("/img/dummy.png");
    const router = useRouter()
    const [pictureChanged, setPictureChanged] = useState(false);

    const handleFormSubmit = (values) => {
        setData(values)
        const _data = jsonToFormData(values)
        if (airCraftId > 0) {
            axios.post(`https://localhost:44319/api/Aircraft/${airCraftId}`, _data,
                {
                    headers: { 'Content-Type': 'multipart/form-data' }
                })
                .then(({ data }) => {
                    console.log("res", data);
                    Swal.fire("Succussfully update!", '', 'success')
                    router.push("/dashboard")
                })
                .catch(err => {
                    console.log("err", err);
                    Swal.fire(err?.message, '', 'error')
                })
        } else {
            axios.post(`https://localhost:44319/api/Aircraft`, _data,
                {
                    headers: { 'Content-Type': 'multipart/form-data' }
                })
                .then(({ data }) => {
                    console.log("res", data);
                    Swal.fire("Succussfully saved!", '', 'success')
                    router.push("/dashboard")
                })
                .catch(err => {
                    console.log("err", err);
                    Swal.fire(err?.message, '', 'error')
                })
        }
    };

    useEffect(() => {
        if (airCraftId > 0) {
            axios.get(`https://localhost:44319/api/Aircraft/${airCraftId}`)
                .then(({ data }) => {
                    console.log("res", data);
                    setData(data);
                })
                .catch(err => {
                    console.log("err", err);
                    Swal.fire(err?.message, '', 'error')
                })

        }

    }, [airCraftId > 0]);

    const getInitialValues = () => {
        return {
            id: data?.id || 0,
            make: data?.make || '',
            model: data?.model || '',
            registration: data?.registration || '',
            dateTime: data?.dateTime || new Date(),
            location: data?.location || '',
            image: `img/aircrafts/${data?.image}` || undefined,
            sighting: data?.sighting || true,
        };
    };

    const getValidationSchema = () => {
        return Yup.object().shape({
            make: Yup.string().required("Make is required")
                .max(128, 'Allow 128 characters only.'),
            model: Yup.string().required("Model is required")
                .max(128, 'Allow 128 characters only.'),
            // location: Yup.string().required("Location is required")
            //     .max(128, 'Allow 255 characters only.'),
            registration: Yup.string().matches(/[a-zA-Z]{1,2}-[a-zA-Z]{1,5}/, 'Invalid Entry.')
            //     .required("Registration is required"),
            // dateTime: Yup.date().max(new Date(), "Must be a Date & Time in the past")
        });
    };

    return (
        <>
            <Formik initialValues={getInitialValues()}
                validationSchema={getValidationSchema()}
                enableReinitialize={true}
                onSubmit={(values, { setSubmitting }) => {
                    setSubmitting(true);
                    handleFormSubmit(values)
                }}>
                {({
                    values,
                    errors,
                    touched,
                    handleChange,
                    handleBlur,
                    handleSubmit,
                    isSubmitting,
                    setFieldValue,
                    submitForm
                    /* and other goodies */
                }) => {
                    return <form onSubmit={handleSubmit}>
                        <Grid container spacing={{ xs: 2, md: 3 }} columns={{ xs: 4, sm: 8, md: 12 }}>
                            <Grid xs={2} sm={4} md={6} marginTop={1}>
                                <FormControl id="make" mb={'20px'} mt='20px' isRequired>
                                    <FormLabel>Make</FormLabel>
                                    <TextField isInvalid={!!errors.make} onChange={handleChange}
                                        type={'text'}
                                        name={'make'}
                                        variant={'outlined'}
                                        value={values.make}
                                    />
                                    {errors.make}
                                </FormControl>
                            </Grid>
                            <Grid xs={2} sm={4} md={6} marginTop={1}>
                                <FormControl id="model" mb={'20px'} mt='20px' isRequired>
                                    <FormLabel>Model</FormLabel>
                                    <TextField isInvalid={!!errors.model} onChange={handleChange}
                                        type={'text'}
                                        name={'model'}
                                        variant={'outlined'}
                                        value={values.model}
                                    />
                                    {errors.model}
                                </FormControl>
                            </Grid>

                            <Grid xs={2} sm={4} md={6} marginTop={1}>
                                <FormControl id="registration" mb={'20px'} mt='20px' isRequired>
                                    <FormLabel>Registration</FormLabel>
                                    <TextField isInvalid={!!errors.registration} onChange={handleChange}
                                        type={'text'}
                                        name={'registration'}
                                        variant={'outlined'}
                                        value={values.registration}
                                    />
                                    {errors.registration}
                                </FormControl>
                            </Grid>
                            {/* <Grid xs={2} sm={4} md={6} marginTop={1}>
                            <FormControl id="location" mb={'20px'} mt='20px' isRequired>
                                <FormLabel>Location</FormLabel>
                                <TextField isInvalid={!!errors.location} onChange={handleChange}
                                    type={'text'}
                                    name={'location'}
                                    variant={'outlined'}
                                    value={values.location}
                                />
                                {errors.location}
                            </FormControl>
                        </Grid> */}

                            {/* <Grid xs={2} sm={4} md={6} marginTop={1}>
                            <FormControl id="dateTime" mb={'20px'} mt='20px' isRequired>
                                <FormLabel>Date & Time</FormLabel>
                                <LocalizationProvider dateAdapter={AdapterDateFns}>
                                    <DateTimePicker isInvalid={!!errors.dateTime}
                                        onChange={e => { setFieldValue("dateTime", e) }}
                                        name={'dateTime'}
                                        variant={'outlined'}
                                        value={new Date(values.dateTime)}
                                        inputFormat="dd/MM/yyyy HH:mm"
                                        renderInput={(params) => <TextField {...params} />}
                                    />
                                </LocalizationProvider>
                                {errors.dateTime}
                            </FormControl>
                        </Grid> */}
                            <Grid xs={2} sm={4} md={6} marginTop={1}>
                                <FormControl id="sighting" mb={'20px'} mt='20px'>
                                    <FormLabel>Sighting</FormLabel>
                                    <Switch name={'sighting'} checked={values?.sighting as boolean}
                                        inputProps={{ 'aria-label': 'controlled' }}
                                        onChange={e => { setFieldValue("sighting", e.target.checked as boolean) }} />
                                </FormControl>
                            </Grid>
                            <Grid xs={2} sm={4} md={6} marginTop={1}>
                                <FormControl id="image" mb={'20px'} mt='20px'>
                                    <FormLabel>Image</FormLabel>
                                    <Input
                                        id="image"
                                        name="image"
                                        type='file'
                                        hidden={true}
                                        onChange={e => {
                                            setImagePreview((e?.currentTarget?.files?.length > 0) ? URL.createObjectURL(e?.currentTarget?.files[0]) : '')
                                            setPictureChanged(true)
                                        }}
                                        onBlur={e => setFieldValue("image", e?.currentTarget?.files[0])}

                                    />
                                </FormControl>
                            </Grid>
                            <Grid>
                                <Card sx={{ maxWidth: 275 }}>
                                    <CardMedia
                                        component="img"
                                        height="140"
                                        image={!pictureChanged ? values.image : imagePreview}
                                        alt="No image"
                                    />
                                </Card>
                            </Grid>
                        </Grid>
                        <Grid xs={12} marginTop={1}>
                            <Button
                                type='submit'
                                variant="outlined">Submit</Button>
                        </Grid>
                    </form>
                }}
            </Formik>
        </>
    )
}
