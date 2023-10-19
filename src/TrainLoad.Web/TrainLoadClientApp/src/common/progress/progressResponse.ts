
export interface ProgressResponse {
    hasResult: boolean;
    progress: number;
}

export const progressMessageComparer = {
        equals: (progress1: ProgressResponse, progress2: ProgressResponse) =>
            progress1.hasResult === progress2.hasResult && progress1.progress === progress2.progress,
};
