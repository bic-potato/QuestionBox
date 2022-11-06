<!--
 * @Author: ZuoXichen
 * @Date: 2022-11-03 16:15:54
 * @LastEditTime: 2022-11-06 11:37:01
 * @LastEditors: ZuoXichen
 * @Description: 
-->
<script setup lang="ts">
import { $fetch } from 'ohmyfetch';
import { ref, onMounted, Ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { Question } from '../model';

const router =  useRouter();
const routes = useRoute();
let STATUS = ref(false);
let data:Ref<Question> = ref({gid:"", question:"", answer:""})

onMounted(async () => {
  const url = "http://127.0.0.1:9700/api";
  let dataurl = ref(`${url}/${routes.params.gid}`)
  const dataRaw = await $fetch<Question>(dataurl.value, { parseResponse: JSON.parse })
  if (dataRaw != undefined) {
    STATUS.value = true;
    data.value = dataRaw;

  }
})

</script>

<template>

</template>