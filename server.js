const express = require('express');
const session = require('express-session');
const path = require('path');

const app = express();
const PORT = process.env.PORT || 3000;

// Configure session middleware
app.use(session({
    secret: 'programming-it-support-secret',
    resave: false,
    saveUninitialized: true,
    cookie: { 
        secure: false,
        maxAge: 30 * 60 * 1000 // 30 minutes
    }
}));

// Set view engine
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, 'views'));

// Serve static files
app.use(express.static(path.join(__dirname, 'public')));
app.use(express.json());

// Data models
const getCategories = () => {
    return [
        {
            name: "Artificial Intelligence",
            id: "AI",
            videos: [
                {
                    title: "Build Everything with AI Agents: Here's How",
                    videoUrl: "https://www.youtube.com/watch?v=XVO3zsHdvio&t=121s&pp=ygUCQUk%3D",
                    thumbnailUrl: "https://img.youtube.com/vi/XVO3zsHdvio/0.jpg",
                    category: "AI"
                },
                {
                    title: "Artificial Intelligence Full Course | Artificial Intelligence Tutorial for Beginners | Edureka",
                    videoUrl: "https://www.youtube.com/watch?v=JMUxmLyrhSk&pp=ygUgYXJ0aWZpY2lhbCBpbnRlbGxpZ2VuY2UgdHV0b3JpYWw%3D",
                    thumbnailUrl: "https://img.youtube.com/vi/JMUxmLyrhSk/hqdefault.jpg",
                    category: "AI"
                },
                {
                    title: "Harvard CS50's Artificial Intelligence with Python Full University Course",
                    videoUrl: "https://www.youtube.com/watch?v=5NgNicANyqM",
                    thumbnailUrl: "https://img.youtube.com/vi/5NgNicANyqM/maxresdefault.jpg",
                    category: "AI"
                }
            ]
        },
        {
            name: "Programming",
            id: "programming",
            videos: [
                {
                    title: "HTML Full Course (freeCodeCamp)",
                    videoUrl: "https://www.youtube.com/watch?v=UB1O30fR-EE",
                    thumbnailUrl: "https://img.youtube.com/vi/UB1O30fR-EE/0.jpg",
                    category: "Web Development"
                },
                {
                    title: "JavaScript Full Course (freeCodeCamp)",
                    videoUrl: "https://www.youtube.com/watch?v=PkZNo7MFNFg",
                    thumbnailUrl: "https://img.youtube.com/vi/PkZNo7MFNFg/0.jpg",
                    category: "Web Development"
                },
                {
                    title: "React JS Full Course (Mosh)",
                    videoUrl: "https://www.youtube.com/watch?v=7kVeCqQCxlk",
                    thumbnailUrl: "https://img.youtube.com/vi/7kVeCqQCxlk/0.jpg",
                    category: "Web Development"
                }
            ]
        },
        {
            name: "IT Support",
            id: "it-support",
            videos: [
                {
                    title: "IBM IT Support - Complete Course | IT Support Technician - Full Course",
                    videoUrl: "https://www.youtube.com/watch?v=BNbPsiCGQzw",
                    thumbnailUrl: "https://img.youtube.com/vi/BNbPsiCGQzw/maxresdefault.jpg",
                    category: "Essential IT Skills"
                },
                {
                    title: "Welcome to IT Support | Google IT Support Certificate",
                    videoUrl: "https://www.youtube.com/watch?v=lJC_sJ6jhDo&list=PLTZYG7bZ1u6pQJShZs9iV0aJNzsqTm4Mx",
                    thumbnailUrl: "https://img.youtube.com/vi/lJC_sJ6jhDo/maxresdefault.jpg",
                    category: "Essential IT Skills"
                }
            ]
        },
        {
            name: "Cybersecurity",
            id: "cybersecurity",
            videos: [
                {
                    title: "the hacker's roadmap (how to get started in IT in 2025)",
                    videoUrl: "https://www.youtube.com/watch?v=5xWnmUEi1Qw",
                    thumbnailUrl: "https://i.ytimg.com/vi/5xWnmUEi1Qw/hqdefault.jpg",
                    category: "Introduction to Cybersecurity"
                },
                {
                    title: "Cybersecurity Mastery: Complete Course in a Single Video",
                    videoUrl: "https://www.youtube.com/watch?v=s19BxFpoSd0",
                    thumbnailUrl: "https://i.ytimg.com/vi/s19BxFpoSd0/hqdefault.jpg",
                    category: "Introduction to Cybersecurity"
                }
            ]
        }
    ];
};

// Routes
app.get('/', (req, res) => {
    const visitorCount = req.session.visitorCount || 1;
    const categories = getCategories();
    
    res.render('index', {
        categories: categories,
        visitorCount: visitorCount
    });
});

app.post('/updateVisitorCount', (req, res) => {
    const count = (req.session.visitorCount || 1) + 1;
    req.session.visitorCount = count;
    res.json({ count: count });
});

app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});