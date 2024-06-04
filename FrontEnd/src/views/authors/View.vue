<template>
    <div class="container">
         <div class="card">
             <div class="card-header">
                 <h4>Authors
                     <RouterLink to="/authors/create" class="btn btn-primary float-end">
                         Add Author
                     </RouterLink>
                 </h4>
             </div>
             <div class="card-body">
                 <table class="table table-bordered">
                     <thead>
                         <tr>
                             <th>Name</th>
                             <th>Bio</th>
                             <th></th>
                         </tr>
                     </thead>
                     <tbody>
                         <tr v-for="(author, index) in this.authors" :key="index">
                            <td>{{ author.name }}</td>
                            <td>{{ author.bio }}</td>
                            <td>
                                <RouterLink :to="{path: '/authors/' + author.id + '/edit'}" class="btn btn-success">
                                    Edit
                                </RouterLink>
                                <button type="button" @click="deleteAuthor(author.id)" class="btn btn-danger">
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
     name: 'authors',
     data(){
         return {
             authors: []
         }
     },
     mounted(){
        this.getAuthors();
     },
     methods: {

        getAuthors(){
            axios.get(this.$config.apiBaseUrl + '/Author').then(res => {
                this.authors = res.data;
            });
        },

        deleteAuthor(authorId){
            axios.delete(this.$config.apiBaseUrl + '/Author?id=' + authorId)
                .then(res => {
                    alert(res.data.message);
                    this.getAuthors();
                });
        }
     }
 }
 </script>