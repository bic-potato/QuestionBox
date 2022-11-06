<!--
 * @Author: ZuoXichen
 * @Date: 2022-11-03 16:15:54
 * @LastEditTime: 2022-11-06 20:53:47
 * @LastEditors: ZuoXichen
 * @Description: 
-->
<script setup lang="ts">
// This starter template is using Vue 3 <script setup> SFCs
// Check out https://vuejs.org/api/sfc-script-setup.html#script-setup
import { NCard, NEllipsis } from 'naive-ui'
import { onMounted, Ref, ref } from 'vue';
import { $fetch } from 'ohmyfetch'
import { Question } from './model';
import { useRouter } from 'vue-router'

const router = useRouter();
let hasContent = ref(false);
let data: Ref<Question[]> = ref([{ gid: "", question: "", answer: "" }]);
const url = "http://127.0.0.1:9700/api"
onMounted(async () => {

  let questionlist = await $fetch<Question[]>(`${url}/`, { parseResponse: JSON.parse })
  if (questionlist != undefined) {
    hasContent.value = true;
    data.value = questionlist;
  }
})



</script>

<template>

  <div
    class="flex text-center text-lg text-white bg-indigo-500 opacity-75 mt-40 w-80 mx-auto h-32 rounded-2xl align-baseline"
    v-on:click="$router.push(`/ask-new`)"><span
      class="antialiased text-center mx-auto my-auto align-middle">欲买桂花同载酒</span>
  </div>
  <n-card class="my-20 w-80 h-40 " v-show="hasContent" :title="question.question" v-for="question in data"
    v-on:click="$router.push(`/question/id${question.gid}`)">
    <n-ellipsis>
      {{ question.answer }}
    </n-ellipsis>
  </n-card>
</template>
