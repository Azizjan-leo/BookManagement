<template>
    <div class="container">
         <div class="card">
             <div class="card-header">
                 <h4>Authors
                     <RouterLink to="/genres/create" class="btn btn-primary float-end">
                         Add Genre
                     </RouterLink>
                 </h4>
             </div>
             <div class="card-body">
                 <table class="table table-bordered">
                     <thead>
                         <tr>
                             <th>Name</th>
                             <th>Description</th>
                             <th></th>
                         </tr>
                     </thead>
                     <tbody>
                         <tr v-for="(genre, index) in this.genres" :key="index">
                            <td>{{ genre.name }}</td>
                            <td>{{ genre.description }}</td>
                            <td>
                                <RouterLink :to="{path: '/genres/' + genre.id + '/edit'}" class="btn btn-success">
                                    Edit
                                </RouterLink>
                                <button type="button" @click="deleteGenre(genre.id)" class="btn btn-danger">
                                    Delete
                                </button>
                            </td>
                         </tr>
                     </tbody>
                 </table>
             </div>
         </div>
    </div>
 </template>
 
 <script>
 import axios from 'axios';
 
 
 export default{
     name: 'genres',
     data(){
         return {
             genres: []
         }
     },
     mounted(){
        this.getGenres();
     },
     methods: {

        getGenres(){
            axios.get(this.$config.apiBaseUrl + '/Genre').then(res => {
                this.genres = res.data;
            });
        },

        deleteGenre(genreId){
            axios.delete(this.$config.apiBaseUrl + '/Genre?id=' + genreId)
                .then(res => {
                    alert(res.data.message);
                    this.getGenres();
                });
        }
     }
 }
 </script>