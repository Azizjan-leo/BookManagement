<template>

    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>Edit Genre</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="">Name</label>
                    <input type="text" v-model="model.genre.name" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="">Description</label>
                    <input type="text" v-model="model.genre.description" class="form-control" />
                </div>
                <div class="mb-3">
                    <button type="button" @click="saveGenre" class="btn btn-primary">Save</button>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
import axios from 'axios';
import router from '@/router';

export default {
    name: 'genreCreate',
    data(){
        return{
            model: {
                genre: {
                    id: '',
                    name: '',
                    description: ''
                }
            }
        }
    },
    mounted(){
        this.getGenre(this.$route.params.id);
    },
    methods: {
        getGenre(genreId){
            axios.get(this.$config.apiBaseUrl + '/Genre/' + genreId)
                .then(res => {
                    this.model.genre = res.data;
                });
        },
        saveGenre(){
            axios.put(this.$config.apiBaseUrl + '/Genre', this.model.genre)
                .then(res => {
                    alert(res.data.message);
                    if(res.status == 200)
                     router.push('/genres');
                });
        }

    }
}
</script>