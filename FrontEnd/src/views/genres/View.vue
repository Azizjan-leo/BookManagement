<template>
    <div>
         <div class="card">
             <div class="card-header">
                 <h4>Genres
                     <RouterLink to="/genre/create" class="btn btn-primary float-end">
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
                                <RouterLink to="/" class="btn btn-success">
                                    Edit
                                </RouterLink>
                                <button type="button" class="btn btn-danger">Delete</button>
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
         console.log('i am here');
     },
     methods: {
         getGenres(){
             axios.get('http://localhost:5170/Genre').then(res => {
                this.genres = res.data;
                console.log(this.genres);
             });
         }
     }
 }
 </script>