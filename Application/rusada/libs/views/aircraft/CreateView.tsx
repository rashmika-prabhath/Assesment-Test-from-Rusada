import React, { useState } from 'react'
import Swal from 'sweetalert2'
import { Grid, FormControl, FormHelperText, FormLabel, TextField, InputLabel, Button, Switch, Box, Card, CardMedia, Input } from '@mui/material';
import { Formik } from 'formik';
import * as Yup from "yup";
import { useRouter } from 'next/router';
import axios from 'axios';
import moment from 'moment';
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
export const CreateView = () => {
    const router = useRouter()
    const [data, setData] = useState<any>([]);
    const handleFormSubmit = (values) => {
        setData(values)
        debugger
        axios.post(`https://localhost:44319/api/AircraftSpot`, data)
            .then(({ data }) => {
                console.log("res", data);
                Swal.fire("Successfully saved!", '', 'success')
                router.push(`/aircraft/${router?.query?.airCraftId }`)
            })
            .catch(err => {
                console.log("err", err);
                Swal.fire(err?.message, '', 'error')
            })

    };

    const getInitialValues = () => {
        return {
            id: data?.id || 0,
            dateTime: data?.dateTime || new Date(),
            location: data?.location || '',
            aircraftId: data?.aircraftId || router?.query?.airCraftId || 0
        };
    };

    const getValidationSchema = () => {
        return Yup.object().shape({
            location: Yup.string().required("Location is required")
                .max(128, 'Allow 255 characters only.'),
            dateTime: Yup.date().required("Date & Time is required").max(new Date(), "Must be a Date & Time in the past")
        });
    };

    return (
        <div className="wrapper" style={{ 'marginTop': '50px' }}>
            <div className="container">
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
                            <h3>Add New Location</h3>
                            <Grid container spacing={{ xs: 2, md: 3 }} columns={{ xs: 4, sm: 8, md: 12 }}>
                                <Grid xs={2} sm={4} md={6} marginTop={1}>
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
                                </Grid>

                                <Grid xs={2} sm={4} md={6} marginTop={1}>
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
            </div>
        </div>
    )
}
export default CreateView;