<template>

    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>Edit Author</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="">Name</label>
                    <input type="text" v-model="model.author.name" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="">Bio</label>
                    <input type="text" v-model="model.author.bio" class="form-control" />
                </div>
                <div class="mb-3">
                    <button type="button" @click="saveAuthor" class="btn btn-primary">Save</button>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
import axios from 'axios';
import router from '@/router';

export default {
    name: 'authorEdit',
    data(){
        return{
            model: {
                author: {
                    id: '',
                    name: '',
                    bio: ''
                }
            }
        }
    },
    mounted(){
        this.getAuthor(this.$route.params.id);
    },
    methods: {
        getAuthor(authorId){
            axios.get(this.$config.apiBaseUrl + '/Author/' + authorId)
                .then(res => {
                    this.model.author = res.data;
                });
        },
        saveAuthor(){
            axios.put(this.$config.apiBaseUrl + '/Author', this.model.author)
                .then(res => {
                    alert(res.data.message);
                    if(res.status == 200)
                     router.push('/authors');
                });
        }

    }
}
</script>