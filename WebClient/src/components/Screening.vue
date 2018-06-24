<template>
  <div>
    <div class="loader" v-if="loading">
    </div>
    <div v-if="!loading">
      <div v-if="error" class="alert alert-danger alert-dismissible fade show" role="alert">
        <strong>{{error}}</strong>
        <button type="button" class="close" aria-label="Close" v-on:click="error = null">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div v-if="success" class="alert alert-success alert-dismissible fade show" role="alert">
        <strong>{{success}}</strong>
        <button type="button" class="close" aria-label="Close" v-on:click="success = null">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div v-if="screening && screening.movie && freeseats">
        <h3>{{screening.time}} - {{screening.date}} - {{screening.movie.movieName}}</h3>
        <h5>Seats:</h5>
        <div v-if="freeseats.length" class="d-flex flex-wrap justify-content-center">
          <div v-for="seat of freeseats" :key="seat.seatid" class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">Row: {{seat.row}} Column: {{seat.column}} </h5>
              <button v-on:click="makeReservation(seat.seatId)" class="btn btn-primary">Reserve</button>
            </div>
          </div>
        </div>
        <table class="table" v-if="screening.nColumns && screenings.nRows">
          <thead>
            <tr>
              <th scope="col">Row/Column</th>
              <th scope="col">Date</th>
              <th scope="col">Movie</th>
              <th scope="col">Reserve</th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>
</template>
<script>
  import axios from 'axios';

  export default {

    name: 'ScreeningFeed',
    props: ['id'],
    data() {
      return {
        loading: false,
        screening: null,
        freeseats: [],
        error: null,
        success: null
      }
    },
    // Fetches posts when the component is created.
    created() {
      this.getData()
    },
    methods: {
      getData() {
        this.loading = true;
        axios.get(`http://localhost:5000/api/Screening/Seats/${this.id}`, {
            headers: {
              'Access-Control-Allow-Origin': '*',
            },
          })
          .then(response => {
            this.screening = response.data.screening
            var temp = this.screening.date.split(",");
            this.screening.date = temp[0];
            this.screening.time = temp[1];
            this.freeseats = response.data.freeSeats
          })
          .catch(e => {
            try {
              this.error = e.response.data.error
            } catch (error) {
              this.error = "Something went wrong"
            }
          })
          .finally(e => {
            this.loading = false
          })
      },
      makeReservation(seatid) {
        this.loading = true;
        console.log({
          screeningId: this.id,
          seatId: seatid
        })
        axios.post(`http://localhost:5000/api/Screening`, {
            screeningId: this.id,
            seatId: seatid,
            headers: {
              'Access-Control-Allow-Origin': '*',
            }
          })
          .then(response => {
            this.success = `Reservation created with id ${response.data.screeningId}:${response.data.seatId}`
          })
          .catch(e => {
            console.log(e)
            try {
              this.error = e.response.data.error
            } catch (error) {
              this.error = "Something went wrong"
            }
          })
          .finally(e => {
            this.getData()
          })
      }
    }
  }

</script>
