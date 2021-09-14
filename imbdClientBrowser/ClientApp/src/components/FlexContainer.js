﻿import React from 'react'

export default function FlexCollection(props) {
    return (
        <section className="d-flex flex-wrap justify-content-evenly">
            {props.children}
        </section>
    )
}

export function Card({ key, children }) {
    return (
        <div key={key} className="card m-2">
            <img src="./placeholder.jpg" className="card-img-top" />
            <div className="card-body d-flex flex-column justify-content-between">
                {children}
            </div>
        </div>
    )
}