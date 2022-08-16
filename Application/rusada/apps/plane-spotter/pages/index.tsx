import styles from './index.module.scss';
import { Box, Button, Grid } from '@mui/material'
import { useRouter } from 'next/router';
export function Index() {
  /*
   * Replace the elements below with your own.
   *
   * Note: The corresponding styles are in the ./index.scss file.
   */
  const router = useRouter();
  return (
    <div className={styles.page}>
      <div className="wrapper">
        <div className="container">
          <div id="welcome">
            <h1>
              <span> Hello there, </span>
              Welcome Plane Spotter Application 👋
            </h1>
          </div>
          <Grid container spacing={2}>
            <Grid item xs={8}>
              <Box m={2} p={2} className='cover my-1'><img src="./img/cover.jpg" alt="cover-image" />
              </Box>
            </Grid>
            <Grid item xs={8}>
              <Box m={2} p={2} className='cover my-1'>
                  <Button onClick={() => {router.push("/dashboard")}} variant='outlined'>Go to Dashboard</Button>
              </Box>
            </Grid>
          </Grid>

        </div>
      </div>
    </div>
  );
}

export default Index;
