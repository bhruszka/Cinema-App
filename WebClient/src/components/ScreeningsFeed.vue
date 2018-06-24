<template>
  <div>
    <div class="loader" v-if="loading">
    </div>
    <div v-if="!loading">
      <table class="table" v-if="screenings && screenings.length">
        <thead>
          <tr>
            <th scope="col">Time</th>
            <th scope="col">Date</th>
            <th scope="col">Movie</th>
            <th scope="col">Reserve</th>
          </tr>
        </thead>
        <tbody>

          <tr v-for="screening of screenings" :key="screening.screeningId">
            <td>{{screening.time}}</td>
            <td>{{screening.date}}</td>
            <td>{{screening.movie.movieName}}</td>
            <td>
              <router-link :to="{ name: 'screening', params: { id: screening.screeningId }}">></router-link>
            </td>
          </tr>

        </tbody>
      </table>
      <div class="alert alert-danger" role="alert" v-if="!(screenings && screenings.length)">
        Application couldn't retrieve data.
      </div>

    </div>
  </div>
</template>
<script>
  import axios from 'axios';
  import moment from 'moment';

  export default {
    name: 'ScreeningFeed',
    data() {
      return {
        screenings: [],
        loading: false,
        error: null
      }
    },
    // Fetches posts when the component is created.
    created() {
      this.loading = true;
      axios.get(`http://localhost:5000/api/Screening`, {
          headers: {
            'Access-Control-Allow-Origin': '*',
          }
        })
        .then(response => {
          console.log(response.data)
          this.screenings = response.data
          this.screenings.forEach(s => {
            var temp = s.date.split(",");
            s.date = temp[0];
            s.time = temp[1];
          });
        })
        .catch(e => {
        })
        .finally(e => {
          this.loading = false
        })
    }
  }

</script>
<style>


</style>
