<template>
  <div>
    <ArticleList :articleType="articleType" />
  </div>
</template>

<script>
import ArticleList from "../components/ArticleList.vue";
export default {
  name: "HomePage",
  data() {
    return {
      articleType: "interview",
    };
  },
  components: {
    ArticleList,
  },
};
</script>
